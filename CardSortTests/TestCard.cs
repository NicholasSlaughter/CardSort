using System;
using Xunit;
using CardSort;

namespace CardSortTests
{
    //Tests the functionality of the Card class
    public class TestCard
    {
        [Fact]
        public void GetCardValue_CreateValidCard_ReturnsExpectedCard()
        {
            try
            {
                Card cardToCreate = new Card(CardValue.Two, CardSuit.Diamonds);
                Assert.Equal(CardValue.Two, cardToCreate.GetCardValue());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }
        [Fact]
        public void GetCardValue_CreateCardWithInvalidCardValue_ReturnsUnableToCreateCard()
        {
            try
            {
                Card cardToCreate = new Card((CardValue)16, CardSuit.Diamonds);
                Assert.True(false);
            }
            catch (ArgumentException e)
            {
                Assert.True(e.ParamName == "cardValue");
            }
        }
        [Fact]
        public void GetCardSuit_CreateValidCard_ReturnsExpectedCard()
        {
            try
            {
                Card cardToCreate = new Card(CardValue.Two, CardSuit.Diamonds);
                Assert.Equal(CardSuit.Diamonds, cardToCreate.GetSuit());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }
        [Fact]
        public void GetCard_CreateCardWithInvalidSuit_ReturnsUnableToCreateCard()
        {
            try
            {
                Card cardToCreate = new Card(CardValue.Two, (CardSuit)'b');
                Assert.True(false);
            }
            catch (ArgumentException e)
            {
                Assert.True(e.ParamName == "suit");
            }
        }
        [Fact]
        public void CardToString_CreateValidCard_ReturnsExpectedCardToString()
        {
            try
            {
                Card cardToCreate = new Card(CardValue.Two, CardSuit.Diamonds);
                string expected = cardToCreate.ToString();
                Assert.Equal("2d", cardToCreate.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }
        [Fact]
        public void CardToString_CompareToWrongExpectedValue_ReturnsExpectedCardToString()
        {
            try
            {
                Card cardToCreate = new Card(CardValue.Two, CardSuit.Diamonds);
                Assert.False("2c" == cardToCreate.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }
    }
}
