using Lab3.Models;

namespace Lab4.View;

public class FigureDto(Figure f)
{
    public int? Id { get; set; } = f.Id;
    public List<StepDto> Steps { get; set; } = (from step in f.Steps select new StepDto(step)).ToList();
}