using StockImporter;
using StockImporter.Interfaces;

namespace WarehouseApp.Domain.Contracts
{
    public interface IFileReader<T> : IReader<T> where T : AbstractWarehouse
    {
    }
}
