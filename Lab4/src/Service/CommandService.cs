using Lab3.Commands;
using Lab3.Data;
using Lab3.Models;
using Lab3.Models.Commands;

namespace Lab4.Service;

public class CommandService : ICommandService
{
    private readonly CommandExecutor _executor = new();
    private readonly TurtleExecutionContext _context = new();

    public CommandService()
    {
        _executor.AddCommands(
            new AngleCommand(_context),
            new ColorCommand(_context),
            new ListCommand(_context),
            new MoveCommand(_context),
            new PenDownCommand(_context),
            new PenUpCommand(_context)
        );
    }

    public void Execute(Turtle turtle, string name, params string[] args)
    {
        _context.Value = turtle;
        _executor.TryExecuteCommand(name, args);
    }
}