namespace ShoppingApp.Services
{
    internal class CartService : ICartService
    {
        private readonly List<CartItem> _cartItems = new();

        public void AddItem(CartItem item)
            => _cartItems.Add(item);

        public IEnumerable<CartItem> Items()
            => _cartItems;

        public void Clear()
            => _cartItems.Clear();

        public double Total()
            => _cartItems.Sum(item => item.Price);
    }
}
