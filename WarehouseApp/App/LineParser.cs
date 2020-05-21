using StockImporter;
using StockImporter.Interfaces;
using System.Linq;

namespace WarehouseApp.App
{
    public class LineParser<T> : IParser<T> where T : AbstractWarehouse
    {
        private T _wc;

        public void Parse(string inputRow)
        {
            var splitRow = inputRow.Split(';');

            if (splitRow.Length == 3)
            {
                ParseResultFromArray(splitRow);
            }
            else
            {
                _wc.LogError("Wrong data input", inputRow);
            }


        }

        public void SetWarehouse(T wc)
        {
            _wc = wc;
        }

        private void ParseResultFromArray(string[] splitRow)
        {
            /*
             * splitRow[0] - product name
             * splitRow[1] - product code
             * 
             */

            var inv = splitRow[2].Split('|');

            if (inv.Any())
            {
                foreach (var i in inv)
                {
                    /*
                     * singleItem[0] - warehouse code
                     * singleItem[1] - quantity
                     */
                    var singleItem = i.Split(',');

                    if (singleItem.Length == 2)
                    {
                        if (string.IsNullOrWhiteSpace(singleItem[0]))
                        {
                            SetError("Warehouse code is missing");
                        }

                        if (int.TryParse(singleItem[1], out int qt))
                        {
                            _wc.AddData(singleItem[0], splitRow[1], qt);
                        }
                        else
                        {
                            SetError($"Unable to parse quantity for product #{splitRow[1]} wh#{singleItem[0]}");
                            _wc.LogImportError(singleItem[0]);
                        }

                    }
                    else
                    {
                        SetError($"Wrong stock data for product #{splitRow[1]}");
                    }
                }
            }
            else
            {
                SetError($"Stock data is missing for product #{splitRow[1]}");
            }


            void SetError(string errorMessage)
            {
                _wc.LogError(errorMessage, splitRow.Aggregate((q, w) => $"{q} {w}"));
            }


        }


    }
}
