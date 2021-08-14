using MediatR;

namespace Concepts.Core.Interfaces
{
    public interface ICommand : IRequest
    {
        
    }
    
    
    public interface ICommand<TOutput> : IRequest<TOutput>
    {
        
    }
}