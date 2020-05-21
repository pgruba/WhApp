using StockImporter;
using StockImporter.Interfaces;
using WarehouseApp.App;

namespace WarehouseApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IReader<MyWarehouse> reader = new FileReader<MyWarehouse>("stocks.txt", '#');
            ISorter<MyWarehouse> sorter = new Sorter<MyWarehouse>();
            MyWarehouse mw = new MyWarehouse("error-item");
            IParser<MyWarehouse> parser = new LineParser<MyWarehouse>();


            //var _lineParser = new LineParser();
            StockImporter.WarehouseCollector<MyWarehouse> wc = new StockImporter.WarehouseCollector<MyWarehouse>(parser, reader, sorter, mw);
            wc.LoadData();
            wc.Print();


        }

        private class MyWarehouse : AbstractWarehouse
        {
            public MyWarehouse(string errorKey) : base(errorKey)
            {
            }
        }
    }
}
