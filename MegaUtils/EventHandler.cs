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
		public CoroutineHandle TpsCoroutine;
		public IEnumerator<float> tpsCoroutine()
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
        public CoroutineHandle TpsAntilag;
		public IEnumerator<float> tpsAntilag()
               {
                   for (; ; )
                   {
                       int ResAntilag1 = {(int)Math.Round(1f / Time.smoothDeltaTime)};
                       if (MegaUtils.instance.Config.TpsRemoveRagdollsUnderDeadline)
                       {
                           if (ResAntilag1 > MegaUtils.instance.Config.TpsDeadline)
                           {
                           foreach (Pickup item in Map.Pickups)
                           item.Destroy();
                           }

                       }
                       if (MegaUtils.instance.Config.TpsRemoveItemsUnderDeadline)
                       {
                           if (ResAntilag1 > MegaUtils.instance.Config.TpsDeadline)
                           {
                           foreach (Ragdoll doll in UnityEngine.Object.FindObjectsOfType<Ragdoll>())
                           NetworkServer.Destroy(doll.gameObject);
                           }

                       }
                   yield return Timing.WaitForSeconds(MegaUtils.instance.Config.TpsCheckDelay);
                   }
               }
		public void OnWaitingForPlayers()
               {
                   if (MegaUtils.instance.Config.TpsDebug) 
                   {
                   Timing.KillCoroutines(tpsCoroutine);
                   Timing.KillCoroutines(tpsAntilag);
                   tpsCoroutine = Timing.RunCoroutine(TpsCoroutine());
                   tpsCoroutine = Timing.RunCoroutine(TpsAntilag());
                   }  
               }
	}
}
