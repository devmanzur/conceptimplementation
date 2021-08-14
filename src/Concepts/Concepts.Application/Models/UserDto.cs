using Concepts.Core.Models;
using Concepts.Core.Utils;

namespace Concepts.Application.Models
{
    public class UserDto
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }
        public WalletDto Wallet { get; private set; }

        public UserDto(User user)
        {
            Id = IdHashUtil.Encode(user.Id);
            Name = user.Name;
            PhoneNumber = user.PhoneNumber;
            Wallet = new WalletDto(user.Wallet);
        }
    }
}