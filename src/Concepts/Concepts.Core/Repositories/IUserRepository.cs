using System.Collections.Generic;
using Concepts.Core.Models;

namespace Concepts.Core.Repositories
{
    public interface IUserRepository
    {
        List<User> GetUsers();
    }
}