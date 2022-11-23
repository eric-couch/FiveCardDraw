using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassExample
{
    public class Deck
    {
        public List<Card> Cards { get; set; } = new List<Card>();
        
        public Deck() {
            ResetDeck();
        }

        public List<Card> DealCards(int numOfCards)
        {
            List<Card> cardsDealt = new List<Card>();
            Random rnd = new Random();
            for (int cardsToDeal = 0; cardsToDeal < numOfCards; cardsToDeal++)
            {
                int cardToSelect = rnd.Next(Cards.Count);
                Card dealtCard = Cards[cardToSelect];
                cardsDealt.Add(dealtCard);
                Cards.RemoveAt(cardToSelect);
            }
            
            return cardsDealt;
        }

        public void ResetDeck()
        {
            Cards.Clear();
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
                    Cards.Add(currentCard);
                }
            }
        }
    }
}
