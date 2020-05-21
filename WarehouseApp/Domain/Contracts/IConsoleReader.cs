using StockImporter;
using StockImporter.Interfaces;

namespace WarehouseApp.Domain.Contracts
{
    interface IConsoleReader<T> : IReader<T> where T : AbstractWarehouse
    {
    }
}
