using System;
using Xunit;
using CardSort;
using System.Collections.Generic;

namespace CardSortTests
{
    //Tests the functionality of the Deck class
    public class TestDeck
    {
        [Fact]
        public void GetCardsFromDeck_CreateValidDeck_ReturnsExpectedCardsFromDeck()
        {
            try
            {
                Deck deckOfCards = new Deck(new List<ICard>()
                {
                    new Card(ValueOfCards.Two,CardSuit.Diamonds),
                    new Card(ValueOfCards.Three,CardSuit.Clubs),
                    new Card(ValueOfCards.Ace,CardSuit.Hearts),
                    new Card(ValueOfCards.Nine,CardSuit.Spades),
                });
                int validCard = 0;

                foreach (Card card in deckOfCards.Cards)
                {
                    if (card.ToString() == "2d" || card.ToString() == "3c" || card.ToString() == "Ah" || card.ToString() == "9s")
                    {
                        validCard += 1;
                    }
                    else
                        Assert.True(false);
                }

                Assert.Equal(4,validCard);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }
        [Fact]
        public void GetCardsFromDeck_CreateInValidDeck_ReturnsUnableToCreateDeck()
        {
            try
            {
                Deck deckOfCards = new Deck(new List<ICard>()
                {
                    new Card("15",CardSuit.Diamonds),
                });

                Assert.True(false);
            }
            catch (ArgumentException e)
            {
                Assert.True(e.ParamName == "cardValue");
            }
        }
        [Fact]
        public void GetCardsFromDeck_CreateEmptyDeck_ReturnsUnableToCreateDeck()
        {
            try
            {
                Deck deckOfCards = new Deck(new List<ICard>() { });

                Assert.True(false);
            }
            catch (ArgumentException e)
            {
                Assert.True(e.ParamName == "cards");
            }
        }
        [Fact]
        public void DeckToString_CreateValidDeck_ReturnsExpectedDeckString()
        {
            try
            {
                Deck deckOfCards = new Deck(new List<ICard>()
                {
                    new Card(ValueOfCards.Jack,CardSuit.Diamonds),
                    new Card(ValueOfCards.Queen,CardSuit.Clubs),
                    new Card(ValueOfCards.King,CardSuit.Hearts),
                    new Card(ValueOfCards.Ace,CardSuit.Spades),
                });
                string expected = "Jd - Jack of Diamonds\nQc - Queen of Clubs\nKh - King of Hearts\nAs - Ace of Spades\n";
                string actual = deckOfCards.ToString();

                Assert.Equal(expected, actual);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }
        [Fact]
        public void DeckToString_CompareToWrongExpectedValue_ReturnsExpectedDeckString()
        {
            try
            {
                Deck deckOfCards = new Deck(new List<ICard>()
                {
                    new Card(ValueOfCards.Jack,CardSuit.Diamonds),
                    new Card(ValueOfCards.Queen,CardSuit.Clubs),
                    new Card(ValueOfCards.King,CardSuit.Hearts),
                    new Card(ValueOfCards.Ace,CardSuit.Spades),
                });
                string notExpected = "11d\n12c\n13h\n14s\n";
                string actual = deckOfCards.ToString();

                Assert.NotEqual(notExpected, actual);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }

        [Fact]
        public void SortDeck_CreateValidDeck_ReturnsExpectedDeck()
        {
            try
            {
                Deck deckOfCards = new Deck(new List<ICard>()
                {
                    new Card(ValueOfCards.Ace,CardSuit.Hearts),
                    new Card(ValueOfCards.Three,CardSuit.Hearts),
                    new Card(ValueOfCards.Five,CardSuit.Diamonds),
                    new Card(ValueOfCards.Three,CardSuit.Spades),
                    new Card(ValueOfCards.Jack,CardSuit.Diamonds),
                    new Card(ValueOfCards.Queen,CardSuit.Clubs),
                    new Card(ValueOfCards.King,CardSuit.Hearts),
                    new Card(ValueOfCards.Seven,CardSuit.Diamonds),
                });
                string expected = "5d - Five of Diamonds\n7d - Seven of Diamonds\nJd - Jack of Diamonds\n3s - Three of Spades\nQc - Queen of Clubs\n3h - Three of Hearts\nKh - King of Hearts\nAh - Ace of Hearts\n";

                deckOfCards.Sort();
                string actual = deckOfCards.ToString();

                Assert.Equal(expected, actual);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }

        [Fact]
        public void SortDeck_CompareToWrongExpectedValue_ReturnsExpectedDeckString()
        {
            try
            {
                Deck deckOfCards = new Deck(new List<ICard>()
                {
                    new Card(ValueOfCards.Seven,CardSuit.Diamonds),
                    new Card(ValueOfCards.Three,CardSuit.Hearts),
                    new Card(ValueOfCards.Five,CardSuit.Diamonds),
                    new Card(ValueOfCards.Three,CardSuit.Spades),
                    new Card(ValueOfCards.Jack,CardSuit.Diamonds),
                    new Card(ValueOfCards.Queen,CardSuit.Clubs),
                    new Card(ValueOfCards.King,CardSuit.Hearts),
                    new Card(ValueOfCards.Ace,CardSuit.Spades),
                });
                string expected = "5d\n7d\n11d\n3s\n14s\n12c\n3h\n13h\n";

                deckOfCards.Sort();
                string actual = deckOfCards.ToString();

                Assert.NotEqual(expected, actual);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }
    }
}
