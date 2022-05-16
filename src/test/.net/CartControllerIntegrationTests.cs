using ShoppingApp.Services;
using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShoppingApp.Tests
{
    [TestClass]
    public class CartControllerIntegrationTests
    {
        #region Helpers
        private static PaymentService CreatePaymentService() => new();
        private static CartService CreateCartService() => new();
        private static ShipmentService CreateShipmentService() => new();
        private static Card CreateCard(double balance) => new(cardNumber: "007", name: "Bond", validTo: DateTime.Today, balance);
        private static AddressInfo CreateAddressInfo() => new(street: "Wellington Square", apartment: 30, city: "London", postalCode: "SW3 4NR", phoneNumber: "007 007 007");
        #endregion

        #region Functionality tests
        [TestMethod]
        public void ValidateController()
        {
            var cartController = new CartController(CreateCartService(), CreatePaymentService(), CreateShipmentService());
            var result = cartController.CheckOut(CreateCard(balance: 10000), CreateAddressInfo());
            Assert.AreEqual("cart empty", result);
        }

        [TestMethod]
        public void ValidateCheckoutCharged()
        {
            var cartService = CreateCartService();
            cartService.AddItem(new CartItem(productId: "Item1", quantity: 1, price: 1000));
            var card = CreateCard(balance: 10000);

            var cartController = new CartController(cartService, CreatePaymentService(), CreateShipmentService());
            
            var result = cartController.CheckOut(card, CreateAddressInfo());
            Assert.AreEqual("charged", result);
        }

        [TestMethod]
        public void ValidateCheckoutNotCharged()
        {
            var cartService = CreateCartService();
            cartService.AddItem(new CartItem(productId: "Item1", quantity: 1, price: 1000));
            var card = CreateCard(balance: 100);
            
            var cartController = new CartController(cartService, CreatePaymentService(), CreateShipmentService());

            var result = cartController.CheckOut(card, CreateAddressInfo());
            Assert.AreEqual("not charged", result);
        }

        [TestMethod]
        public void ValidateMultipleItemsCheckedOut()
        {
            var cartService = CreateCartService();
            cartService.AddItem(new CartItem(productId: "Item1", quantity: 1, price: 1000));
            cartService.AddItem(new CartItem(productId: "Item2", quantity: 1, price: 1000));
            
            var cartController = new CartController(cartService, CreatePaymentService(), CreateShipmentService());

            var card = CreateCard(balance: 10000);
            var result = cartController.CheckOut(card, CreateAddressInfo());
            
            Assert.AreEqual("charged", result);            
            Assert.AreEqual(8000, card.Balance);
            Assert.AreEqual(0, cartService.Items().Count());
        }
        #endregion
    }
}