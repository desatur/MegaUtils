using Exiled.API.Features;
using Exiled;
using System.Threading;
using System;
using UnityEngine;

namespace MegaUtils
{
	partial class EventHandler
	{
		public void OnWaitingForPlayers()
		{
			while (true) {
			if (MegaUtils.instance.Config.TpsDebug) Log.Info((int)Math.Round(1.0f / Time.smoothDeltaTime));
		    Thread.Sleep(MegaUtils.instance.Config.TpsCheckDelay);
			}
		}
	}
}