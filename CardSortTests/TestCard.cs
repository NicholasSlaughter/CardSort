using System;
using Xunit;
using CardSort;

namespace CardSortTests
{
    public class TestCard
    {
        [Fact]
        public void GetCardValue_CreateValidCard_ReturnsExpectedCard()
        {
            try
            {
                Card cardToCreate = new Card(1, "d");
                Assert.Equal(1, cardToCreate.GetCardValue());
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
                Card cardToCreate = new Card(16, "d");
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
                Card cardToCreate = new Card(1, "d");
                Assert.Equal("d", cardToCreate.GetSuit());
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
                Card cardToCreate = new Card(1, "b");
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
                Card cardToCreate = new Card(1, "d");
                Assert.Equal("1d", cardToCreate.ToString());
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
                Card cardToCreate = new Card(1, "d");
                Assert.False("1c" == cardToCreate.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }
    }
}
