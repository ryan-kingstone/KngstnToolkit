using System.Collections.Generic;
using MusicAggregate.Lib.Providers;

namespace MusicAggregate.Lib
{
    public class AggregateEngine
    {
        private readonly List<ISearchProvider> _providers;

        public AggregateEngine()
        {
            _providers = new List<ISearchProvider>
            {
                new SoundcloudProvider()
            };

        }

        public Dictionary<ISearchProvider, List<string>> Search(string query)
        {
            Dictionary<ISearchProvider, List<string>> results = new Dictionary<ISearchProvider, List<string>>();

            foreach(var provider in _providers)
            {
                var result = provider.Search(query);
                results.Add(provider, result);
            }

            return results;
        }
    }
}
