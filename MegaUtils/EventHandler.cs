using System;
using System.Collections.Generic;
using Exiled.API.Features;
using MEC;
using UnityEngine;
using Exiled.Events.EventArgs;

namespace MegaUtils
{
	public class EventHandler
	{
		public CoroutineHandle tpsCoroutine;
		public IEnumerator<float> TpsCoroutine()
               {
                   for (; ; )
                   {
                        if (MegaUtils.instance.Config.TpsDebug)
                        {
                        Log.Info($"TPS: {(int)Math.Round(1f / Time.smoothDeltaTime)}");
                        }
                   yield return Timing.WaitForSeconds(MegaUtils.instance.Config.TpsCheckDelay);
                   }
               }
		public void OnWaitingForPlayers()
               {
                   if (MegaUtils.instance.Config.TpsDebug) 
                   {
                   tpsCoroutine = Timing.RunCoroutine(TpsCoroutine());
                   }  
               }
		public void OnRoundEnded(RoundEndedEventArgs ev)
               {
                   if (MegaUtils.instance.Config.TpsDebug) 
                   {
                   Timing.KillCoroutines(tpsCoroutine);
                   }  
               }
	}
}
