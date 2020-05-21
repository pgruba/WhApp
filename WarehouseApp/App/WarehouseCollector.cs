using StockImporter;
using StockImporter.Exceptions;
using StockImporter.Interfaces;
using System;
using System.Linq;

namespace WarehouseApp.App
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
            _parser = lineParser ?? throw new MissingParserException();
            _reader = reader ?? throw new MissingReaderException();
            _sorter = sorter ?? throw new MissingSorterException();
            _wc = wareHouse ?? throw new ArgumentNullException("Warehouse object");

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

        private void SortCollection()
        {
            throw new NotImplementedException();
        }
    }
}
