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
            Player ComputerPlayer = new Player();

            Console.Write("Please enter your name: ");
            ThisPlayer.Name = Console.ReadLine();
            ThisPlayer.Hand = FiveCardDrawDeck.DealCards(5);
            ComputerPlayer.Hand = FiveCardDrawDeck.DealCards(5);

            Console.WriteLine("Here are your cards:");
            CardGame.ShowHand(ThisPlayer.Hand, true);
            bool quitGame = false;
            // Main Game Loop
            do
            {
                Console.Write("How many cards would you like to discard (Q to quit)? ");
                string discards = Console.ReadLine();
                // check for Q to quit
                if (discards != "Q")
                {
                    if (Int32.TryParse(discards, out int replaceCardNum))
                    {
                        // if four, check for ace in hand
                        if (replaceCardNum == 4)
                        {
                            if (CardGame.CheckForAce(ThisPlayer.Hand))
                            {
                                CardGame.ReplaceCards(replaceCardNum, ThisPlayer.Hand, FiveCardDrawDeck);
                            }
                            else
                            {
                                Console.WriteLine($"You don't have Ace {ThisPlayer.Name}. Try again.");
                                continue;
                            }
                        } // check that it's a number between 0-3
                        else if (replaceCardNum < 0 || replaceCardNum > 3)
                        {
                            Console.WriteLine("Not allowed.  Try again.");
                        }
                        else
                        {
                            CardGame.ReplaceCards(replaceCardNum, ThisPlayer.Hand, FiveCardDrawDeck);
                        }
                        Console.Clear();
                        Console.WriteLine($"{ThisPlayer.Name}'s Hand: ");
                        CardGame.ShowHand(ThisPlayer.Hand, true);
                        Console.WriteLine($"{ThisPlayer.Name}'s Hand Rank: {CardGame.DetermineHand(ThisPlayer.Hand)}");
                        Console.WriteLine("Computer Player's Hand");
                        CardGame.ShowHand(ComputerPlayer.Hand, true);
                        Console.WriteLine($"Computer Player's Hand Rank: {CardGame.DetermineHand(ComputerPlayer.Hand)}");
                    }
                    
                }
                quitGame = true;
            } while (!quitGame);
        }
    }
}