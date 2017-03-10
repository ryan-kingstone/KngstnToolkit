using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicAggregate.Lib
{
    public interface ISearchProvider
    {
        List<string> Search(string query);
    }
}
