using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicAggregate.Lib
{
    public class AggregateEngine
    {
        private List<ISearchProvider> Providers;

        public AggregateEngine()
        {
            Providers = new List<ISearchProvider>();
        }

        public Dictionary<ISearchProvider, List<string>> Search(string query)
        {
            Dictionary<ISearchProvider, List<string>> results = new Dictionary<ISearchProvider, List<string>>();

            foreach(var provider in Providers)
            {
                var result = provider.Search(query);
                results.Add(provider, result);
            }

            return results;
        }
    }
}
