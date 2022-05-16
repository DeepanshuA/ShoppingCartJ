using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShoppingApp.Tests
{
    [TestClass]
    public class CardTests
    {
        #region Validate properties
        [TestMethod]
        public void TestCardProperties()
        {
            var card = new Card(cardNumber: "007", name: "Bond", validTo: DateTime.Today, balance: 10000);
            
            Assert.AreEqual("007", card.CardNumber);
            Assert.AreEqual("Bond", card.Name);
            Assert.AreEqual(DateTime.Today, card.ValidTo);
            Assert.AreEqual(10000, card.Balance);
        }
        #endregion

        #region Functionality tests
        [TestMethod]
        public void TestChargeCard()
        {
            var card = new Card(cardNumber: "007", name: "Bond", validTo: DateTime.Today, balance: 10000);

            Assert.AreEqual(10000, card.Balance);

            Assert.IsTrue(card.Charge(5000));
            Assert.AreEqual(5000, card.Balance);

            Assert.IsFalse(card.Charge(10000));
            Assert.AreEqual(5000, card.Balance);
        }

        [TestMethod]
        public void TestAddCredit()
        {
            var card = new Card(cardNumber: "007", name: "Bond", validTo: DateTime.Today, balance: 10000);

            Assert.AreEqual(10000, card.Balance);

            card.AddCredit(10000);
            Assert.AreEqual(20000, card.Balance);
        }
        #endregion

        #region Invalid inputs
        [TestMethod]
        public void TestNegativeCharge()
        {
            var card = new Card(cardNumber: "007", name: "Bond", validTo: DateTime.Today, balance: 10000);

            Assert.ThrowsException<ArgumentException>(() => card.Charge(-1000));

            Assert.AreEqual(10000, card.Balance);
        }

        [TestMethod]
        public void TestNegativeAddCredit()
        {
            var card = new Card(cardNumber: "007", name: "Bond", validTo: DateTime.Today, balance: 10000);

            Assert.ThrowsException<ArgumentException>(() => card.AddCredit(-1000));

            Assert.AreEqual(10000, card.Balance);
        }
        #endregion

        #region Negative Tests
        [TestMethod]
        public void TestValidToIsNotChecked()
        {
            var yesterday = DateTime.Today.AddDays(-1);
            var card = new Card(cardNumber: "007", name: "Bond", validTo: yesterday, balance: 10000);

            Assert.AreEqual(10000, card.Balance);

            Assert.IsTrue(card.Charge(5000));
            Assert.AreEqual(5000, card.Balance);
        }
        #endregion
    }
}