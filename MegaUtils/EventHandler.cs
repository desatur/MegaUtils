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
                         Log.Info((int)Math.Round(1f / Time.smoothDeltaTime));
                         yield return Timing.WaitForSeconds(MegaUtils.instance.Config.TpsCheckDelay);
                    }
                }
		public void OnWaitingForPlayers()
                {
                     tpsCoroutine = Timing.RunCoroutine(TpsCoroutine());
                }
		public void OnRoundEnded(RoundEndedEventArgs ev)
                {
                     Timing.KillCoroutines(tpsCoroutine);
                }
	}
}
