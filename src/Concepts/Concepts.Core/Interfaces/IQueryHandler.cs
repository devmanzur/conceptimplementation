using MediatR;

namespace Concepts.Core.Interfaces
{
    public interface IQueryHandler<TQuery> : IRequestHandler<TQuery>
        where TQuery : IQuery
    {
    }

    public interface IQueryHandler<TQuery, TOutput> : IRequestHandler<TQuery, TOutput>
        where TQuery : IQuery<TOutput>
    {
    }
}