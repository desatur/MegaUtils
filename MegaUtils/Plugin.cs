using System;
using Exiled.API.Features;

namespace MegaUtils
{
	public class MegaUtils : Plugin<Config>
	{
		public static MegaUtils instance;

		private EventHandler ev { get; set; }

		public override string Name => "MegaUtils";

		public override string Author { get; } = "AtomSnow";

        public override Version RequiredExiledVersion { get; } = new Version(5, 0, 0);

        public override string Prefix { get; } = "MegaUtils";

        public override Version Version { get; } = new Version(0, 1, 0);

		public override void OnEnabled()
		{
			instance = this;
			ev = new EventHandler();
			Exiled.Events.Handlers.Server.WaitingForPlayers += ev.OnWaitingForPlayers;
		}

		public override void OnDisabled() 
		{
			base.OnDisabled();
			Exiled.Events.Handlers.Server.WaitingForPlayers -= ev.OnWaitingForPlayers;
			ev = null;
		}

	}
}