namespace StockImporter.Interfaces
{
    public interface IParser<T> where T : AbstractWarehouse
    {
        void Parse(string inputRow);
        void SetWarehouse(T wc);
    }
}
