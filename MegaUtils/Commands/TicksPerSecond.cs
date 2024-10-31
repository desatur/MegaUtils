using CommandSystem;
using Exiled.API.Features;

namespace MegaUtils.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    [CommandHandler(typeof(ClientCommandHandler))]
    public class TicksPerSecond : ICommand
    {
        public string Command => "tickspersecond";
        public string[] Aliases => ["tps"];
        public string Description => "Get's the server's tick per second rate.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = $"TPS: {Server.Tps}/{ServerStatic.ServerTickrate}";
            return true;
        }
    }
}
