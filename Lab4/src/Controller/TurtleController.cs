using Lab3.Commands;
using Lab3.Data;
using Lab3.Models;
using Lab4.Service;
using Lab4.View;
using Microsoft.AspNetCore.Mvc;

namespace Lab4.Controller;

[Route("api/turtle")]
[ApiController]
public class TurtleController(TurtleContext context, ICommandService commands) : ControllerBase
{
    
    [HttpGet]
    public ActionResult<List<TurtleDto>> GetTurtles()
    {
        return (
            from turtle in context.Turtles
            select new TurtleDto(turtle)
        ).ToList();
    }
    
    [HttpGet]
    [Route("{id}")]
    public ActionResult<TurtleFullDto> GetTurtle(int id)
    {
        var result = (
            from turtle in context.Turtles
            where turtle.Id == id
            select new TurtleFullDto(turtle)
        ).FirstOrDefault();

        if (result == null)
        {
            return NotFound();
        }

        return result;
    }

    [HttpPost]
    [Route("{id}")]
    public ActionResult<TurtleFullDto> ExecuteCommand(int id, [FromBody] CommandQueryDto query)
    {
        var turtle = (
            from t in context.Turtles
            where t.Id == id
            select t
        ).FirstOrDefault();

        string[] args = {};

        if (query.Argument.Trim() != "")
        {
            args = new[] { query.Argument };
        }

        if (turtle == null)
        {
            return NotFound();
        }

        try
        {
            commands.Execute(turtle, query.Command, args);
        }
        catch (ExecutionException e)
        {
            return BadRequest(e.Message);
        }

        return new TurtleFullDto(turtle);
    }
}