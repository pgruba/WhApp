using StockImporter;
using StockImporter.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace WarehouseApp.App
{
    public class Sorter<T> : ISorter<T> where T : AbstractWarehouse
    {
        public IList<KeyValuePair<string, Dictionary<string, int>>> Sort(T input)
        {
            return input.Stocks.ToList()
                    .OrderByDescending(q => q.Value
                        .Where(w => w.Key != input.ErrorKey).Sum(q => q.Value))
                    .ToList();
        }
    }
}
