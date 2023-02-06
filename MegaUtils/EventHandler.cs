using System;
using System.Collections.Generic;
using Exiled.API.Features;
using MEC;
using Exiled.Events.EventArgs;

namespace MegaUtils
{
	public class EventHandler
	{
		public CoroutineHandle tpscoroutine;
		public IEnumerator<float> tpsCoroutine() {
                   for (; ; )
                   {
                        if (MegaUtils.instance.Config.TpsDebug)
                        {
                        Log.Info($"TPS: {Server.Tps}");
                        }
                   yield return Timing.WaitForSeconds(MegaUtils.instance.Config.TpsCheckDelay);
                   }
               }
		public void OnWaitingForPlayers() {
                    Log.Info($"Server is Waiting for players, stopping and starting Coroutines.");
                    if (MegaUtils.instance.Config.TpsDebug) 
                    {
                        Timing.KillCoroutines(tpscoroutine);
                        tpscoroutine = Timing.RunCoroutine(tpsCoroutine());
                    }  
                }
	}
}
