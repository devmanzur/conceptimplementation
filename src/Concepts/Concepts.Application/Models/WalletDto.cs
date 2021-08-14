using Concepts.Core.Models;
using Concepts.Core.Utils;

namespace Concepts.Application.Models
{
    public class WalletDto
    {
        public WalletDto(Wallet wallet)
        {
            Id = IdHashUtil.Encode(wallet.Id);
            Balance = $"BDT {wallet.Balance:F}";
        }

        public string Id { get; private set; }
        public string Balance { get; private set; }
    }
}