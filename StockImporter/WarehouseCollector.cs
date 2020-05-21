using StockImporter.Interfaces;
using System;
using System.Linq;

namespace StockImporter
{
    public class WarehouseCollector<T> where T : AbstractWarehouse
    {
        private IParser<T> _parser;
        private IReader<T> _reader;
        private ISorter<T> _sorter;
        private T _wc;

        public WarehouseCollector(
            IParser<T> lineParser,
            IReader<T> reader,
            ISorter<T> sorter,
            T wareHouse)
        {
            _parser = lineParser;
            _reader = reader;
            _sorter = sorter;
            _wc = wareHouse;

            _reader.SetParser(_parser)
                .SetWarehouse(_wc);

        }

        public void LoadData()
        {
            _reader.ReadData();
        }



        public void Print()
        {
            var sortResult = _sorter.Sort(_wc);


            foreach (var wh in sortResult)
            {
                Console.WriteLine($"{wh.Key} (total {wh.Value.Where(q => q.Key != _wc.ErrorKey).Sum(q => q.Value)})");
                foreach (var prods in wh.Value)
                {
                    Console.WriteLine($"{prods.Key}: {prods.Value}");
                }
                Console.WriteLine();
            }

            Console.Read();
        }
    }
}
