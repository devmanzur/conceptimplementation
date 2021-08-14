namespace Concepts.Core.Models
{
    public class Wallet
    {
        public Wallet()
        {
            Balance = 0;
        }

        //database identifier
        public long Id { get; private set; }
        public decimal Balance { get; private set; }
    }
}