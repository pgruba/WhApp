using System.Collections.Generic;

namespace WarehouseApp.Domain
{
    public class ParserResult
    {
        public ParserResult()
        {
            Product = new ParserResultItem();
            //ParseIt(splitRow);
        }



        public ParserResultItem Product { get; set; }
        public string Error { get; set; }
        public bool HasError => !string.IsNullOrEmpty(Error);

        public string ImportedRow { get; set; }

        public class ParserResultItem
        {
            public ParserResultItem()
            {
                Inventory = new Dictionary<string, int>();
            }
            public string Id { get; set; }
            public string Name { get; set; }

            public IDictionary<string, int> Inventory { get; set; }

        }
    }
}
