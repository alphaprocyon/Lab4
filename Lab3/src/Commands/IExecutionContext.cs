using Lab3.Data;

namespace Lab3.Commands;

public interface IExecutionContext<T>
    where T : class, ILoadable<T>
{
    T Value { get; set; }
}