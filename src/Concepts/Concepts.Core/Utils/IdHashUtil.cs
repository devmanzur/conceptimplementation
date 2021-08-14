using System.Linq;
using System.Text;
using HashidsNet;

namespace Concepts.Core.Utils
{
    public static class IdHashUtil
    {
        private const string DefaultSalt = "51435732-5700-45df-890f-76b816ecd8c4";
        public static string Encode(long id)
        {
            var hashids = new Hashids(DefaultSalt);
            var hash = hashids.EncodeLong(id);
            return hash;
        }

        public static long Decode(string hash)
        {var hashids = new Hashids(DefaultSalt);
            var id = hashids.DecodeLong(hash);
            return id.First();
        }
    }
}