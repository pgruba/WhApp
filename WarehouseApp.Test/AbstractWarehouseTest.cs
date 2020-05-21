using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockImporter;

namespace WarehouseApp.Test
{
    [TestClass]
    public class AbstractWarehouseTest
    {
        private AbstractWarehouse _aw;


        [TestMethod]
        public void Add_Nulls_Should_LogError()
        {
            _aw = new AbstractWarehouseTestClass("errorKey");
            _aw.AddData(null, null, 0);
            Assert.IsTrue(_aw.HasError);
        }

        [TestMethod]
        public void Add_EmptyLines_Should_LogError()
        {
            _aw = new AbstractWarehouseTestClass("errorKey");
            _aw.AddData("", "", 0);
            Assert.IsTrue(_aw.HasError);
        }

        [TestMethod]
        public void Add_EmptyProduct_Should_LogError_In_Warehouse()
        {
            _aw = new AbstractWarehouseTestClass("errorKey");
            _aw.AddData("WH01", "", 0);
            Assert.AreEqual(1, _aw.Stocks["WH01"]["errorKey"]);
        }
    }

    internal class AbstractWarehouseTestClass : AbstractWarehouse
    {
        internal AbstractWarehouseTestClass(string errorKey)
                : base(errorKey)
        {

        }
    }
}
