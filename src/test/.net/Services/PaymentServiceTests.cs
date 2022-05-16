using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingApp.Services;

namespace ShoppingApp.Tests
{
    [TestClass]
    public class PaymentServiceTests
    {
        #region Functionality tests
        [TestMethod]
        public void TestChargeCard()
        {
            var card = new Card(cardNumber: "007", name: "Bond", validTo: DateTime.Today, balance: 10000);
            Assert.AreEqual(10000, card.Balance);

            var paymentService = new PaymentService();
            Assert.IsTrue(paymentService.Charge(5000, card));

            Assert.AreEqual(5000, card.Balance);
        }

        [TestMethod]
        public void TestValidToIsChecked()
        {
            var yesterday = DateTime.Today.AddDays(-1);
            var card = new Card(cardNumber: "007", name: "Bond", validTo: yesterday, balance: 10000);

            Assert.AreEqual(10000, card.Balance);

            var paymentService = new PaymentService();
            Assert.IsFalse(paymentService.Charge(5000, card));

            Assert.AreEqual(10000, card.Balance);
        }
        #endregion

        #region Invalid inputs
        [TestMethod]
        public void TestNegativeCharge()
        {
            var card = new Card(cardNumber: "007", name: "Bond", validTo: DateTime.Today, balance: 10000);

            var paymentService = new PaymentService();
            Assert.ThrowsException<ArgumentException>(() => paymentService.Charge(-1000, card));

            Assert.AreEqual(10000, card.Balance);
        }

        [TestMethod]
        public void TestInvalidCard()
        {
            var paymentService = new PaymentService();
            Assert.ThrowsException<ArgumentNullException>(() => paymentService.Charge(1000, card: null!));

        }
        #endregion
    }
}