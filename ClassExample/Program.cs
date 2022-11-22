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

            Console.Write("Please enter your name: ");
            ThisPlayer.Name = Console.ReadLine();
            ThisPlayer.Hand = FiveCardDrawDeck.DealCards(5);
            
            Console.WriteLine("Here are your cards:");
            ShowHand(ThisPlayer.Hand);
            bool quitGame = false;
            // Main Game Loop
            do
            {
                Console.Write("How many cards would you like to discard (Q to quit)? ");
                string discards = Console.ReadLine();
                // check for Q to quit
                if (discards == "Q")
                {
                    break;
                }
                // parse user input to a number of cards to draw
                if (Int32.TryParse(discards, out int replaceCardNum))
                {
                    // if four, check for ace in hand
                    if (replaceCardNum == 4)
                    {
                        if (CheckForAce(ThisPlayer.Hand))
                        {
                            ReplaceCards(replaceCardNum, ThisPlayer.Hand, FiveCardDrawDeck);
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
                        continue;
                    } else
                    {
                        ReplaceCards(replaceCardNum, ThisPlayer.Hand, FiveCardDrawDeck);
                    }

                }
                quitGame= true;
            } while (!quitGame);

            Console.Clear();
            Console.WriteLine($"{ThisPlayer.Name} Hand: ");
            ShowHand(ThisPlayer.Hand);
        }

        public static void ShowHand(List<Card> handCards)
        {
            int cardNum = 1;
            string cardPos = String.Empty;
            foreach (Card card in handCards)
            {
                Console.Write($"{card.ToString()}\t");
                cardPos += $"({cardNum++})\t";
            }
            Console.WriteLine($"\n{cardPos}\n");
            return;
        }

        public static bool CheckForAce(List<Card> cards)
        {
            bool aceInHand = false;
            foreach (Card card in cards)
            {
                if (card.rank == "A")
                {
                    aceInHand = true;
                }
            }
            return aceInHand;
        }

        public static void ReplaceCards(int numOfReplace, List<Card> CardsInHand, Deck DeckToDealFrom)
        {
            for (int replaceCardCounter = 0; replaceCardCounter< numOfReplace; replaceCardCounter++)
            {
                Console.WriteLine("Which card to discard? (1-5)");
                string replacement = Console.ReadLine();
                if (Int32.TryParse(replacement, out int replacementNum))
                {
                    if (replacementNum >= 1 && replacementNum <= 5) {
                        // IEnumerable
                        CardsInHand[replacementNum - 1] = DeckToDealFrom.DealCards(1).FirstOrDefault();
                    } else
                    {
                        Console.WriteLine("Try and real card number.");
                        replaceCardCounter--;
                        continue;
                    }
                }
            }
            return;
        }
    }
}