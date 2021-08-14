using System.Collections.Generic;
using System.Threading.Tasks;
using Concepts.Core.Models;

namespace Concepts.Core.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
    }
}