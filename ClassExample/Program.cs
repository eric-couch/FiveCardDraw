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
            Deck FiveCardDrawDeck = new Deck();
            Player ThisPlayer = new Player();

            Console.WriteLine($"How many cards before we deal: {FiveCardDrawDeck.Cards.Count}");

            Console.Write("Please enter your name: ");
            ThisPlayer.Name = Console.ReadLine();
            ThisPlayer.Hand = FiveCardDrawDeck.DealCards(5);
            
            Console.WriteLine("Here are your cards:");
            foreach (Card card in ThisPlayer.Hand)
            {
                Console.Write($"{card.ToString()}\t");
            }
            Console.WriteLine();
            Console.WriteLine($"How many cards left in our deck: {FiveCardDrawDeck.Cards.Count}");

            //Console.WriteLine();

        }

        
    }
}