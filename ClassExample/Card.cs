namespace ClassExample
{
    public class Card
    {
        public string suit { get; set; }
        public string rank { get; set; }
        public int val { get; set; }

        /// <summary>
        /// This is a card class
        /// </summary>
        /// <param name="rank">A, K, Q, J, 10, 9...2</param>
        /// <param name="suit">spades, hearts, clubs, diamonds (use ASCII code)</param>
        public Card(string rank, string suit, int val)
        {
            this.suit = suit;
            this.rank = rank;
            this.val = val;
        }

        public override string? ToString()
        {
            return String.Format($"{rank}{suit}");
        }
    }
}
