using Exiled.API.Enums;
using Exiled.API.Features;
using MegaUtils.Utilities;

namespace MegaUtils
{
	public class MegaUtils : Plugin<Config>
	{
		public static MegaUtils Instance { get; private set; }
        public EventHandler EventHandler { get; set; }

		public override string Name => "MegaUtils";
        public override string Prefix { get; } = "MegaUtils";
        public override string Author { get; } = "Desatur";
        public override Version RequiredExiledVersion { get; } = new Version(8, 0, 0);
        public override Version Version { get; } = new Version(1, 0, 0);

		public override PluginPriority Priority { get; } = PluginPriority.First;

		public override void OnEnabled()
		{
			Instance = this;
			EventHandler = new EventHandler();
            Exiled.Events.Handlers.Server.WaitingForPlayers += EventHandler.OnWaitingForPlayers;
			base.OnEnabled();
		}

		public override void OnDisabled() 
		{
			EventHandler = null;
            Exiled.Events.Handlers.Server.WaitingForPlayers -= EventHandler.OnWaitingForPlayers;
            base.OnDisabled();
		}

        public override void OnRegisteringCommands()
        {
			UnregisterVanillaCommand.Unregister("ping");
            base.OnRegisteringCommands();
        }
    }
}
