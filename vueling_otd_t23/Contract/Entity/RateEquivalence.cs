
namespace Contract.Entity
{
    public class RateEquivalence
    {
        /// <summary>
        /// Money country from.
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// Money country to.
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// Equivalence.
        /// </summary>
        public decimal Rate { get; set; }

    }
}
