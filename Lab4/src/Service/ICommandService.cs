using Lab3.Models;

namespace Lab4.Service;

public interface ICommandService
{
    void Execute(Turtle turtle, string name, params string[] args);
}