using Concepts.Core.Models;

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
            Name = user.Name;
            PhoneNumber = user.PhoneNumber;
            Wallet = new WalletDto(user.Wallet);
        }
    }

    public class WalletDto
    {
        public WalletDto(Wallet userWallet)
        {
            Balance = $"BDT {userWallet.Balance:F}";
        }

        public string Id { get; private set; }
        public string Balance { get; private set; }
    }
}