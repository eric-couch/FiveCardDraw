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
            bool isFlush = false;
            bool isStraight = false;

            HandRank thisHandRank = HandRank.HighCard;
            //if (cards.GroupBy(c => c.suit).Count() > 1)
            //{
            //    isFlush = false;
            //}

            string lastSuit = cards[0].suit;
            for (int cardNum = 1; cardNum <= cards.Count; cardNum++)
            {
                if (cards[cardNum].suit != lastSuit)
                {
                    isFlush = false;
                    break;
                }
                else
                {
                    isFlush = true;
                    lastSuit = cards[cardNum].suit;
                }
            }
            if (isFlush)
            {
                thisHandRank = HandRank.Flush;
            }
            return thisHandRank;
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
