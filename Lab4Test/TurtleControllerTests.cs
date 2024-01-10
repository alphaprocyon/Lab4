using Lab3.Data;
using Lab3.Models;
using Lab4.Controller;
using Lab4.Service;
using Moq;
using Moq.EntityFrameworkCore;

namespace Lab4Test;

public class TurtleControllerTests
{
    private readonly Mock<TurtleContext> mockContext;
    private readonly TurtleController controller;

    public TurtleControllerTests()
    {
        mockContext = new Mock<TurtleContext>();
        controller = new TurtleController(mockContext.Object, new CommandService());
    }
    
    [SetUp]
    public void Setup()
    {
        mockContext.Reset();
        mockContext
            .Setup(context => context.Steps)
            .ReturnsDbSet(CreateFakeEmptyStepList());
        mockContext
            .Setup(context => context.Figures)
            .ReturnsDbSet(CreateFakeEmptyFigureList());
    }

    [Test]
    public void GetTurtles_ReturnsAllTurtles()
    {
        var turtles = CreateFakeTurtleList(78);
        mockContext
            .Setup(context => context.Turtles)
            .ReturnsDbSet(turtles);
        
        var result = controller.GetTurtles();

        Assert.That(turtles, Has.Count.EqualTo(result.Value?.Count ?? 0));
    }

    [Test]
    public void GetTurtle_ReturnsCorrectTurtle()
    {
        var turtles = CreateFakeTurtleList(10);
        mockContext
            .Setup(context => context.Turtles)
            .ReturnsDbSet(turtles);

        var expected = turtles[7];
        var result = controller.GetTurtle(7);
        
        Assert.That(result.Value?.Id, Is.EqualTo(expected.Id));
    }

    private List<Turtle> CreateFakeTurtleList(int count)
    {
        List<Turtle> result = new();

        for (int i = 0; i < count; ++i)
        {
            result.Add(new Turtle
            {
                Id = i
            });
        }

        return result;
    }

    private List<Step> CreateFakeEmptyStepList()
    {
        return new();
    }
    
    private List<Figure> CreateFakeEmptyFigureList()
    {
        return new();
    }
}