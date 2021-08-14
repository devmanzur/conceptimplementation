using MediatR;

namespace Concepts.Core.Interfaces
{
    public interface IQuery : IRequest
    {
        
    }
    
    
    public interface IQuery<TOutput> : IRequest<TOutput>
    {
        
    }
}