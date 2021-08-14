using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Concepts.Application.Models;
using Concepts.Core.Interfaces;
using Concepts.Core.Models;
using Concepts.Core.Repositories;

namespace Concepts.Application.UseCases.GetUsers
{
    public class GetUsersQuery : IQuery<List<UserDto>>
    {
        
    }
    
    public class GetUsersQueryHandler : IQueryHandler<GetUsersQuery,List<UserDto>>
    {
        private readonly IUserRepository _userRepository;

        public GetUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public async Task<List<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetUsers();
            return users.Select(x => new UserDto(x)).ToList();
        }
    }
}