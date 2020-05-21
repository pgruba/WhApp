namespace StockImporter.Interfaces
{
    public interface IReader<T> where T : AbstractWarehouse
    {
        void ReadData();
        IParser<T> SetParser(IParser<T> parser);
    }
}
