using System.Collections.Generic;
using System.Linq;

namespace StockImporter
{
    public class AbstractWarehouse
    {

        private IList<(string Message, string Row)> _errors { get; set; }
        private IDictionary<string, Dictionary<string, int>> _warehouse;
        public string ErrorKey { get; }
        public bool HasError => _errors.Any();
        public IDictionary<string, Dictionary<string, int>> Stocks => _warehouse;

        public AbstractWarehouse(string errorKey)
        {
            _errors = new List<(string Message, string Row)>();
            _warehouse = new Dictionary<string, Dictionary<string, int>>();
            ErrorKey = errorKey;
        }

        public bool AddData(string warehouseCode, string productCode, int quantity)
        {
            if (string.IsNullOrWhiteSpace(warehouseCode))
            {
                LogError($"Empty warehouse code for product #{productCode ?? ""}", "");
                return false;
            }

            if (!ProductCodeIsValid(warehouseCode, productCode))
            {
                return false;
            }

            if (_warehouse.ContainsKey(warehouseCode))
            {
                if (_warehouse[warehouseCode].ContainsKey(productCode))
                {
                    _warehouse[warehouseCode][productCode] += quantity;
                }
                else
                {
                    _warehouse[warehouseCode].Add(productCode, quantity);
                }
                return true;
            }
            else
            {
                _warehouse.Add(warehouseCode, new Dictionary<string, int>()
                {
                    {productCode,quantity }
                });
                return true;
            }
        }



        public void LogImportError(string whCode)
        {
            AddData(whCode, ErrorKey, 1);
        }

        public void LogError(string message, string row)
        {
            _errors.Add((message, row));
        }

        private bool ProductCodeIsValid(string warehouseCode, string productCode)
        {
            if (string.IsNullOrWhiteSpace(productCode))
            {
                LogImportError(warehouseCode);
                return false;
            }
            return true;
        }

    }




}
