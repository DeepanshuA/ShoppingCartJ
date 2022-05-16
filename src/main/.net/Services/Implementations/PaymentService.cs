namespace ShoppingApp.Services
{
    internal class PaymentService : IPaymentService
    {
        public bool Charge(double total, Card card)
        {
            if (card is null)
                throw new ArgumentNullException(nameof(card));

            if (card.ValidTo < DateTime.Today)
                return false;

            return card.Charge(total);
        }
    }
}
