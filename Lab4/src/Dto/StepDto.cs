using Lab3.Models;

namespace Lab4.View;

public class StepDto(Step s)
{
    public int Id { get; set; } = s.Id;
    public int StartX { get; set; } = s.StartX;
    public int StartY { get; set; } = s.StartY;
    public int EndX { get; set; } = s.EndX;
    public int EndY { get; set; } = s.EndY;
    public bool PenDown { get; set; } = s.PenDown;
    public PenColor Color { get; set; } = s.Color;
}