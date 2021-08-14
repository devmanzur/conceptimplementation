using MediatR;

namespace Concepts.Core.Interfaces
{
    public interface ICommandHandler<TCommand> : IRequestHandler<TCommand>
        where TCommand : ICommand
    {
    }

    public interface ICommandHandler<TCommand, TOutput> : IRequestHandler<TCommand, TOutput>
        where TCommand : ICommand<TOutput>
    {
    }
}