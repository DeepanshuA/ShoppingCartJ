namespace ShoppingApp
{
    public sealed class CartItem
    {
        public string ProductId { get; }

        private int _quantity;
        public int Quantity => _quantity;

        private double _price;
        public double Price => _price;

        public CartItem(string productId, int quantity, double price)
        {
            ProductId = productId;
            _quantity = quantity;
            _price = price;
        }

        public void Add(int quantityToAdd, double priceIncrement)
        {
            if (quantityToAdd <= 0)
                throw new ArgumentException("Must be positive", nameof(quantityToAdd));

            if (priceIncrement <= 0)
                throw new ArgumentException("Must be positive", nameof(priceIncrement));

            _quantity += quantityToAdd;
            _price += priceIncrement;
        }

        public void Remove(int quantityToRemove, double priceDecrement)
        {
            if (quantityToRemove <= 0)
                throw new ArgumentException("Must be positive", nameof(quantityToRemove));

            if (quantityToRemove > _quantity)
                throw new ArgumentException($"Must be less than 'Quantity: {_quantity}'", nameof(quantityToRemove));

            if (priceDecrement <= 0)
                throw new ArgumentException("Must be positive", nameof(priceDecrement));

            if (priceDecrement > _price)
                throw new ArgumentException($"Must be less than 'Price: {_price}'", nameof(priceDecrement));

            _quantity -= quantityToRemove;
            _price -= priceDecrement;
        }
    }
}