namespace Lab3.Models.Commands;

using Lab3.Commands;

public class PenUpCommand(TurtleExecutionContext turtle) : ICommand
{
	public string Name => "pu";

	public void Execute(params string[] args)
    {
		turtle.Value.PenUp();
		turtle.Value.PrintState();
    }

	public override string ToString() => $"{Name}: command to put up the pen.";
}
