using Lab3.Commands;

namespace Lab3.Models;

public class TurtleExecutionContext : IExecutionContext<Turtle>
{
    public Turtle Value { get; set; } = null!;
}