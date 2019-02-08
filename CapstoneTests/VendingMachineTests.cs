using Capstone;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineTests
    {
        [TestMethod]
        public void FeedMoneyTest_WhenEntering_5Dollars_BalanceIs_5Dollars()
        {
            VendingMachine vm = new VendingMachine();

            vm.FeedMoney("5");

            Assert.AreEqual(5, vm.MachineBalance, "Machine Balance should increase by 5 dollars.");
        }
        [TestMethod]
        public void FeedMoneyTest_WhenEntering_3Dollars_MachineBalance_DoesNotChange()
        {
            VendingMachine vm = new VendingMachine();

            vm.FeedMoney("3");

            Assert.AreEqual(0, vm.MachineBalance, "Amount is invalid, so MachineBalance doesn't update.");
        }
        [TestMethod]
        public void SelectProductTest_If_ProductCode_DoesNotExixt_Customer_IsReturnedTo_PurchaseMenu()
        {

        }
    }
}
