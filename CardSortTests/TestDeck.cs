using System;
using Xunit;
using CardSort;
using System.Collections.Generic;

namespace CardSortTests
{
    public class TestDeck
    {
        [Fact]
        public void GetCardsFromDeck_CreateValidDeck_ReturnsExpectedCardsFromDeck()
        {
            try
            {
                Deck deckOfCards = new Deck(new List<ICard>()
                {
                    new Card(1,"d"),
                    new Card(2,"c"),
                    new Card(14,"h"),
                    new Card(9,"s"),
                });
                int validCard = 0;

                foreach (Card card in deckOfCards.Cards)
                {
                    if (card.ToString() == "1d" || card.ToString() == "2c" || card.ToString() == "14h" || card.ToString() == "9s")
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
                    new Card(15,"d"),
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
                    new Card(11,"d"),
                    new Card(12,"c"),
                    new Card(13,"h"),
                    new Card(14,"s"),
                });
                string expected = "Jd\n\nQc\n\nKh\n\nAs";
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
                    new Card(11,"d"),
                    new Card(12,"c"),
                    new Card(13,"h"),
                    new Card(14,"s"),
                });
                string notExpected = "11d\n\n12c\n\n13h\n\n14s";
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
                    new Card(7,"d"),
                    new Card(3,"h"),
                    new Card(5,"d"),
                    new Card(3,"s"),
                    new Card(11,"d"),
                    new Card(12,"c"),
                    new Card(13,"h"),
                    new Card(14,"s"),
                });
                string expected = "5d\n\n7d\n\nJd\n\n3s\n\nAs\n\nQc\n\n3h\n\nKh";

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
                    new Card(7,"d"),
                    new Card(3,"h"),
                    new Card(5,"d"),
                    new Card(3,"s"),
                    new Card(11,"d"),
                    new Card(12,"c"),
                    new Card(13,"h"),
                    new Card(14,"s"),
                });
                string expected = "5d\n\n7d\n\n11d\n\n3s\n\n14s\n\n12c\n\n3h\n\n13h";

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
