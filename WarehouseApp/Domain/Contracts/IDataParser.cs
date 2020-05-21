using System.Collections.Generic;

namespace WarehouseApp.Domain.Contracts
{
    public interface IDataParser
    {
        ParserResult ParseRow(string row);
        IList<ParserResult> ParseRows(string[] rows);
    }
}
