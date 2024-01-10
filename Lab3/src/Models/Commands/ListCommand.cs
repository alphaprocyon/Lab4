namespace Lab3.Models.Commands;

using Lab3.Commands;

public class ListCommand(TurtleExecutionContext turtle) : ICommand
{
	public string Name => "list";

	public void Execute(params string[] args)
	{
		if (args.Length != 1)
		{
			throw new ExecutionException($"'{Name}' accepts exactly one argument");
		}

		string arg = args[0].ToLower();

		if (arg == "steps")
		{
			turtle.Value.PrintSteps();
			return;
		}

		if (arg == "figures")
		{
			turtle.Value.PrintFigures();
			return;
		}

		throw new ExecutionException($"'{Name}' accepts either 'steps' or 'figures'.");
	}

	public override string ToString() {
		string result = $"{Name} steps: command to show all executed steps.\n";
		result += $"\t{Name} figures: command to show all properties of completed figures.";

		return result;
	}
}
