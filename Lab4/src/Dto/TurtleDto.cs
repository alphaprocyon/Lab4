using Lab3.Models;

namespace Lab4.View;

public class TurtleDto(Turtle t)
{
    public int? Id { get; set; } = t.Id;
    public int X { get; set; } = t.X;
    public int Y { get; set; } = t.Y;
    public int Direction { get; set; } = t.Direction;
    public bool PenIsDown { get; set; } = t.PenIsDown;
}

public class TurtleFullDto(Turtle t): TurtleDto(t)
{
    public List<StepDto> steps { get; set; } = (from step in t.Steps select new StepDto(step)).ToList();
    public List<StepDto> path { get; set; } = (from step in t.Path select new StepDto(step)).ToList();
    public List<FigureDto> figures { get; set; } = (from figure in t.Figures select new FigureDto(figure)).ToList();
}
