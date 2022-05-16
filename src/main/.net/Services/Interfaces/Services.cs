namespace ShoppingApp.Services
{

    public interface ICartService
    {
        void AddItem(CartItem item);
        void Clear();
        IEnumerable<CartItem> Items();
        double Total();
    }

    public interface IPaymentService
    {
        bool Charge(double total, Card card);
    }

    public interface IShipmentService
    {
        void Ship(AddressInfo info, IEnumerable<CartItem> items);
    }
}