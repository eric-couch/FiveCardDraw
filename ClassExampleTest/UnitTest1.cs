using ClassExample;

namespace ClassExampleTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestCardHandForAce_True()
        {
            // Arrange
            List<Card> Hand = new List<Card>()
            {
                new Card("A", "♣",14),
                new Card("5", "♣",5),
                new Card("6", "♣",6),
                new Card("7", "♣",7),
                new Card("8", "♣",8)
            };
            // Act
            bool aceInHand = CardGame.CheckForAce(Hand);
            // Assert 
            Assert.IsTrue(aceInHand);
        }

        [Test]
        public void TestCardHandForAce_False()
        {
            // Arrange
            List<Card> Hand = new List<Card>()
            {
                new Card("4", "♣",4),
                new Card("5", "♣",5),
                new Card("6", "♣",6),
                new Card("7", "♣",7),
                new Card("8", "♣",8)
            };
            // Act
            bool aceInHand = CardGame.CheckForAce(Hand);
            // Assert 
            Assert.IsFalse(aceInHand);
        }

        [Test]
        public void CardHandTestForFourOfAKind_True ()
        {
            // Arrange
            List<Card> Hand = new List<Card>()
            {
                new Card("4", "♣",4),
                new Card("4", "♠",4),
                new Card("4", "♥",4),
                new Card("4", "♦",4),
                new Card("8", "♣",8)
            };
            // Act
            CardGame.HandRank myHandRank = CardGame.DetermineHand(Hand);
            // Assert 
            Assert.AreEqual(CardGame.HandRank.FourOfAKind, myHandRank);
        }

        [Test]
        public void CardHandTestForFourOfAKind_False()
        {
            // Arrange
            List<Card> Hand = new List<Card>()
            {
                new Card("4", "♣",4),
                new Card("4", "♠",4),
                new Card("4", "♥",4),
                new Card("3", "♦",3),
                new Card("8", "♣",8)
            };
            // Act
            CardGame.HandRank myHandRank = CardGame.DetermineHand(Hand);
            // Assert 
            Assert.AreNotEqual(CardGame.HandRank.FourOfAKind, myHandRank);
        }

        [Test]
        public void CardHandTestForFullHouse_True()
        {
            // Arrange
            List<Card> Hand = new List<Card>()
            {
                new Card("4", "♣",4),
                new Card("4", "♠",4),
                new Card("4", "♥",4),
                new Card("3", "♦",3),
                new Card("3", "♣",3)
            };
            // Act
            CardGame.HandRank myHandRank = CardGame.DetermineHand(Hand);
            // Assert 
            Assert.AreEqual(CardGame.HandRank.FullHouse, myHandRank);
        }

        [Test]
        public void CardHandTestForFullHouse_False()
        {
            // Arrange
            List<Card> Hand = new List<Card>()
            {
                new Card("4", "♣",4),
                new Card("4", "♠",4),
                new Card("4", "♥",4),
                new Card("3", "♦",3),
                new Card("2", "♣",2)
            };
            // Act
            CardGame.HandRank myHandRank = CardGame.DetermineHand(Hand);
            // Assert 
            Assert.AreNotEqual(CardGame.HandRank.FullHouse, myHandRank);
        }

        [Test]
        public void CardHandTestForThreeOfAKind_True()
        {
            // Arrange
            List<Card> Hand = new List<Card>()
            {
                new Card("4", "♣",4),
                new Card("4", "♠",4),
                new Card("4", "♥",4),
                new Card("2", "♦",2),
                new Card("3", "♣",3)
            };
            // Act
            CardGame.HandRank myHandRank = CardGame.DetermineHand(Hand);
            // Assert 
            Assert.AreEqual(CardGame.HandRank.ThreeOfAKind, myHandRank);
        }

        [Test]
        public void CardHandTestForThreeOfAKind_False()
        {
            // Arrange
            List<Card> Hand = new List<Card>()
            {
                new Card("4", "♣",4),
                new Card("4", "♠",4),
                new Card("4", "♥",4),
                new Card("3", "♦",3),
                new Card("3", "♣",3)
            };
            // Act
            CardGame.HandRank myHandRank = CardGame.DetermineHand(Hand);
            // Assert 
            Assert.AreNotEqual(CardGame.HandRank.ThreeOfAKind, myHandRank);
        }

        [Test]
        public void CardHandTestForTwoPair_True()
        {
            // Arrange
            List<Card> Hand = new List<Card>()
            {
                new Card("4", "♣",4),
                new Card("4", "♠",4),
                new Card("3", "♥",3),
                new Card("2", "♦",2),
                new Card("3", "♣",3)
            };
            // Act
            CardGame.HandRank myHandRank = CardGame.DetermineHand(Hand);
            // Assert 
            Assert.AreEqual(CardGame.HandRank.TwoPair, myHandRank);
        }

        [Test]
        public void CardHandTestForTwoPair_False()
        {
            // Arrange
            List<Card> Hand = new List<Card>()
            {
                new Card("4", "♣",4),
                new Card("6", "♠",6),
                new Card("4", "♥",4),
                new Card("2", "♦",2),
                new Card("3", "♣",3)
            };
            // Act
            CardGame.HandRank myHandRank = CardGame.DetermineHand(Hand);
            // Assert 
            Assert.AreNotEqual(CardGame.HandRank.TwoPair, myHandRank);
        }

    }
}