using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassExample
{
    public static class CardGame
    {
        public enum HandRank
        {
            HighCard,
            Pair,
            TwoPair,
            ThreeOfAKind,
            Straight,
            Flush,
            FullHouse,
            FourOfAKind,
            StraightFlush
        }

        // assuming five cards for now
        public static HandRank DetermineHand(List<Card> cards)
        {

            HandRank thisHandRank = HandRank.HighCard;

            var cardGroups = from c in cards
                             group c by new { c.val } into g
                             select new { rank = g.Key, count = g.Count() };

            if (cardGroups.Where(c => c.count == 4).Any())
            {
                thisHandRank = HandRank.FourOfAKind;
            } else if (cardGroups.Where(c => c.count == 3).Any())
            {
                if (cardGroups.Where(c => c.count == 2).Any())
                {
                    thisHandRank = HandRank.FullHouse;
                } else
                {
                    thisHandRank = HandRank.ThreeOfAKind;
                }
            } else if (cardGroups.Where(c => c.count == 2).Any())
            {
                if (cardGroups.Where(c => c.count == 2).Count() == 2)
                {
                    thisHandRank = HandRank.TwoPair;
                } else
                {
                    thisHandRank = HandRank.Pair;
                }
            }

            return thisHandRank;
        }


        public static bool CheckForAce(List<Card> cards)
        {
            return cards.Exists(c => c.rank == "A");
        }

        public static void ShowHand(List<Card> handCards, bool ShowPos)
        {
            int cardNum = 1;
            string cardPos = String.Empty;
            foreach (Card card in handCards)
            {
                Console.Write($"{card.ToString()}\t");
                cardPos += $"({cardNum++})\t";
            }
            if (ShowPos)
            {
                Console.WriteLine($"\n{cardPos}\n");
            }
            return;
        }

        public static void ReplaceCards(int numOfReplace, List<Card> CardsInHand, Deck DeckToDealFrom)
        {
            for (int replaceCardCounter = 0; replaceCardCounter < numOfReplace; replaceCardCounter++)
            {
                Console.WriteLine("Which card to discard? (1-5)");
                string replacement = Console.ReadLine();
                if (Int32.TryParse(replacement, out int replacementNum))
                {
                    if (replacementNum >= 1 && replacementNum <= 5)
                    {
                        // IEnumerable
                        CardsInHand[replacementNum - 1] = DeckToDealFrom.DealCards(1).FirstOrDefault();
                    }
                    else
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
