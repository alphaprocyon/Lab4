using System.Text.RegularExpressions;

namespace Lab3.Commands
{
	public class CommandExecutor
	{
		private readonly Dictionary<string, ICommand> _commands = new();

		public CommandExecutor(params ICommand[] commands)
		{
		}

		public void AddCommands(params ICommand[] commands)
		{
			foreach (var command in commands)
			{
				_commands[command.Name] = command;
			}
		}

		public void TryExecuteCommand(string name, params string[] args)
		{
			if (_commands.TryGetValue(name, out var command))
			{
				command.Execute(args);
			}
			else
			{
				throw new ExecutionException("Unknown command. Use 'help' to see all commands.");
			}
		}

		public static int? ParseIntArg(string arg)
		{
			if (int.TryParse(arg, out int result))
			{
				return result;
			}

			return null;
		}
	}
}
