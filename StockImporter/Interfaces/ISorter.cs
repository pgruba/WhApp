using System.Collections.Generic;

namespace StockImporter.Interfaces
{
    public interface ISorter<T> where T : AbstractWarehouse
    {
        IList<KeyValuePair<string, Dictionary<string, int>>> Sort(T input);
    }
}
