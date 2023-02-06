using System;
using Exiled.API.Features;
using Exiled.API.Enums;
using ServerHandler = Exiled.Events.Handlers.Server;
using PlayerHandler = Exiled.Events.Handlers.Player;

namespace MegaUtils
{
	public class MegaUtils : Plugin<Config>
	{
		public static MegaUtils instance;

		private EventHandler ev { get; set; }

		public override string Name => "MegaUtils";

		public override string Author { get; } = "AtomSnow";

        public override Version RequiredExiledVersion { get; } = new Version(3, 0, 0);

        public override string Prefix { get; } = "MegaUtils";

        public override Version Version { get; } = new Version(0, 2, 0);

		public override PluginPriority Priority { get; } = PluginPriority.First;

		public override void OnEnabled()
		{
			instance = this;
			ev = new EventHandler();
			ServerHandler.WaitingForPlayers += ev.OnWaitingForPlayers;
			
			base.OnEnabled();
		}

		public override void OnDisabled() 
		{
		    ServerHandler.WaitingForPlayers -= ev.OnWaitingForPlayers;
			
			ev = null;
			base.OnDisabled();
		}

	}
}
