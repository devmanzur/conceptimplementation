using System.Collections.Generic;

namespace Concepts.Core.Models
{
    public class User
    {
        public User(long id, string name, string phoneNumber)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            Wallet = new Wallet();
        }

        //database identifier
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }
        public Wallet Wallet { get; private set; }
    }
}