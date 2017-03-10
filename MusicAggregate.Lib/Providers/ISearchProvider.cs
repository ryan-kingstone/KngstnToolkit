using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace MusicAggregate.Lib.Providers
{
    public interface ISearchProvider
    {
        List<string> Search(string query);
    }
}
