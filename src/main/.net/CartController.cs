using ShoppingApp.Services;

namespace ShoppingApp
{
    public class CartController
    {
        private readonly ICartService _cartService;
        private readonly IPaymentService _paymentService;
        private readonly IShipmentService _shipmentService;

        public CartController(ICartService cartService, IPaymentService paymentService, IShipmentService shipmentService)
        {
            _cartService = cartService;
            _paymentService = paymentService;
            _shipmentService = shipmentService;
        }

        public string CheckOut(Card card, AddressInfo addressInfo)
        {
            if (!_cartService.Items().Any())
                return "cart empty";

            var result = _paymentService.Charge(_cartService.Total(), card);
            if (result)
            {
                _shipmentService.Ship(addressInfo, _cartService.Items());
                _cartService.Clear();
                return "charged";
            }
            else
            {
                return "not charged";
            }
        }
    }
}