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
                    new Card(CardValue.Two,CardSuit.Diamonds),
                    new Card(CardValue.Three,CardSuit.Clubs),
                    new Card(CardValue.Ace,CardSuit.Hearts),
                    new Card(CardValue.Nine,CardSuit.Spades),
                });
                int validCard = 0;

                foreach (Card card in deckOfCards.Cards)
                {
                    if (card.ToString() == "2d" || card.ToString() == "3c" || card.ToString() == "14h" || card.ToString() == "9s")
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
                    new Card((CardValue)15,CardSuit.Diamonds),
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
                    new Card(CardValue.Jack,CardSuit.Diamonds),
                    new Card(CardValue.Queen,CardSuit.Clubs),
                    new Card(CardValue.King,CardSuit.Hearts),
                    new Card(CardValue.Ace,CardSuit.Spades),
                });
                string expected = "Jd\nQc\nKh\nAs\n";
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
                    new Card(CardValue.Jack,CardSuit.Diamonds),
                    new Card(CardValue.Queen,CardSuit.Clubs),
                    new Card(CardValue.King,CardSuit.Hearts),
                    new Card(CardValue.Ace,CardSuit.Spades),
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
                    new Card(CardValue.Seven,CardSuit.Diamonds),
                    new Card(CardValue.Three,CardSuit.Hearts),
                    new Card(CardValue.Five,CardSuit.Diamonds),
                    new Card(CardValue.Three,CardSuit.Spades),
                    new Card(CardValue.Jack,CardSuit.Diamonds),
                    new Card(CardValue.Queen,CardSuit.Clubs),
                    new Card(CardValue.King,CardSuit.Hearts),
                    new Card(CardValue.Ace,CardSuit.Spades),
                });
                string expected = "5d\n7d\nJd\n3s\nAs\nQc\n3h\nKh\n";

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
                    new Card(CardValue.Seven,CardSuit.Diamonds),
                    new Card(CardValue.Three,CardSuit.Hearts),
                    new Card(CardValue.Five,CardSuit.Diamonds),
                    new Card(CardValue.Three,CardSuit.Spades),
                    new Card(CardValue.Jack,CardSuit.Diamonds),
                    new Card(CardValue.Queen,CardSuit.Clubs),
                    new Card(CardValue.King,CardSuit.Hearts),
                    new Card(CardValue.Ace,CardSuit.Spades),
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
