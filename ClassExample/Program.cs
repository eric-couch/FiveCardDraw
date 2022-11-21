namespace ClassExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Using the Card class that we created earlier, 
             * create a program that deals a player 5 cards.  
             * With time permitting, implement the ability 
             * for a user to discard up to 4 cards if they 
             * have an Ace, or 3 if they do not.  Then deal 
             * the player new cards for every card discarded.
             */
            List<Card> Deck = new List<Card>();

            for (int rank = 2; rank <= 14; rank++)
            {
                for (int suit = 0; suit < 4; suit++)
                {
                    string convertedRank = String.Empty;
                    string convertedSuit = String.Empty;

                    switch (rank)
                    {
                        case 11:
                            convertedRank = "J";
                            break;
                        case 12:
                            convertedRank = "Q";
                            break;
                        case 13:
                            convertedRank = "K";
                            break;
                        case 14:
                            convertedRank = "A";
                            break;
                        default:
                            convertedRank = rank.ToString();
                            break;
                    }
                    switch (suit)
                    {
                        case 0:
                            convertedSuit = "♠";
                            break;
                        case 1:
                            convertedSuit = "♣";
                            break;
                        case 2:
                            convertedSuit = "♥";
                            break;
                        case 3:
                            convertedSuit = "♦";
                            break;
                    }

                    Card currentCard = new Card(convertedRank, convertedSuit, rank);
                    Deck.Add(currentCard);
                }
            }
            //foreach (Card thisCard in Deck)
            //{
            //    Console.WriteLine($"Rank: {thisCard.rank} Suit: {thisCard.suit}");
            //}
            Console.WriteLine("Here are your cards:");
            for (int cardNum = 0; cardNum < 5; cardNum++)
            {
                Card thisCard = DealCard(Deck);
                Console.Write($"{thisCard.ToString()}\t");
            }
            Console.WriteLine();
            Console.WriteLine($"How many cards left in our deck: {Deck.Count}");
        }

        public static Card DealCard(List<Card> cards)
        {
            Random rnd = new Random();
            int cardToSelect = rnd.Next(cards.Count);
            Card dealtCard = cards[cardToSelect];
            cards.RemoveAt(cardToSelect);
            return dealtCard;
        }
    }
}