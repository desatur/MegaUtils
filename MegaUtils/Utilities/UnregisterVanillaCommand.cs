using CommandSystem;
using RemoteAdmin;

namespace MegaUtils.Utilities
{
    public static class UnregisterVanillaCommand
    {
        public static void Unregister(string command_name, bool remote_admin = true, bool client_command = true, bool server_console_command = true)
        {
            try
            {
                if (remote_admin)
                {
                    foreach (ICommand command in CommandProcessor.RemoteAdminCommandHandler.AllCommands.Where(x => x.Command == command_name))
                    {
                        CommandProcessor.RemoteAdminCommandHandler.UnregisterCommand(command);
                    }
                }
                if (client_command)
                {
                    foreach (ICommand command in GameCore.Console.singleton.ConsoleCommandHandler.AllCommands.Where(x => x.Command == command_name))
                    {
                        GameCore.Console.singleton.ConsoleCommandHandler.UnregisterCommand(command);
                    }
                }
                if (server_console_command)
                {
                    foreach (ICommand command in QueryProcessor.DotCommandHandler.AllCommands.Where(x => x.Command == command_name))
                    {
                        QueryProcessor.DotCommandHandler.UnregisterCommand(command);
                    }
                }
            }
            catch { };
        }
    }
}
