namespace Lab3.Models.Commands;

using Lab3.Commands;

public class PenDownCommand(TurtleExecutionContext turtle) : ICommand
{
	public string Name => "pd";

	public void Execute(params string[] args)
    {
		turtle.Value.PenDown();
		turtle.Value.PrintState();
    }

	public override string ToString() => $"{Name}: command to put down the pen.";
    }
