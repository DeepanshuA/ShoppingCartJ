namespace ShoppingApp
{
    public sealed class Card
    {
        public string CardNumber { get; }
        public string Name { get; }
        public DateTime ValidTo { get; }

        private double _balance;
        public double Balance => _balance;

        public Card(string cardNumber, string name, DateTime validTo, double balance)
        {
            CardNumber = cardNumber;
            Name = name;
            ValidTo = validTo;
            _balance = balance;
        }

        public bool Charge(double total)
        {
            if (total < 0)
                throw new ArgumentException("Must be non-negative", nameof(total));

            if (total > _balance)
                return false;

            _balance -= total;
            return true;
        }

        public void AddCredit(double credit)
        {
            if (credit < 0)
                throw new ArgumentException("Must be non-negative", nameof(credit));

            _balance += credit;
        }
    }
}