
namespace Services.Entity
{
    public class TransactionEquivalence
    {
        /// <summary>
        /// Transaction Id.
        /// </summary>
        public string Sku { get; set; }

        /// <summary>
        /// Money country.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Amount of transaction.
        /// </summary>
        public decimal Amount { get; set; }

    }
}
