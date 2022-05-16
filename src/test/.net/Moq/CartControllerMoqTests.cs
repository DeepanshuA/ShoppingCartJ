
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingApp.Services;

namespace ShoppingApp.Tests
{
    using Moq;

    [TestClass]
    public class CartControllerMoqTests
    {
        [TestMethod]
        public void ValidateCheckoutCharged()
        {
            #region Create mock objects
            
            var paymentServiceMock = new Mock<IPaymentService>();
            var cartServiceMock = new Mock<ICartService>();
            var shipmentServiceMock = new Mock<IShipmentService>();

            #endregion

            #region Setup mock objects

            // Setup PaymentServiceMock.Charge() method to always return true
            paymentServiceMock.Setup(p => p.Charge(It.IsAny<double>(), It.IsAny<Card>())).Returns(true);
            
            // Setup CartServiceMock.Items() to always return 1 cart item.
            cartServiceMock.Setup(c => c.Items()).Returns(new[] { new CartItem(productId: "Item1", quantity: 1, price: 1000) });

            #endregion

            #region Create CartController with mock services

            // NOTE: We are **not** creating a Mock<CartController>.
            //       We want to test the functionality of the real CartController, with mock services.
            var controller = new CartController(cartServiceMock.Object, paymentServiceMock.Object, shipmentServiceMock.Object);

            #endregion

            #region Invoke "CheckOut" method on the CartController

            var card = new Card(cardNumber: "007", name: "Bond", validTo: DateTime.Today, balance: 10000);
            var addressInfo = new AddressInfo(street: "Wellington Square", apartment: 30, city: "London", postalCode: "SW3 4NR", phoneNumber: "007 007 007");
            var result = controller.CheckOut(card, addressInfo);

            #endregion

            #region Verify that Clear method was invoked CartServiceMock

            cartServiceMock.Verify(s => s.Clear(), Times.Once());

            #endregion

            #region Verify that Ship method was invoked on ShipmentServiceMock

            shipmentServiceMock.Verify(s => s.Ship(addressInfo, It.IsAny<IEnumerable<CartItem>>()), Times.Once());

            #endregion

            #region Verify that CheckOut method returns "charged"

            Assert.AreEqual("charged", result);

            #endregion
        }

        [TestMethod]
        public void ValidateCheckoutNotCharged()
        {
            // TODO: Add Moq based test
        }

        [TestMethod]
        public void ValidateMultipleItemsCheckedOut()
        {
            // TODO: Add Moq based test
        }
    }
}