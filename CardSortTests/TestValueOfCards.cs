using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CardSort;

namespace CardSortTests
{
    //Tests the functionality of the Value Of Cards class
    public class TestValueOfCards
    {
        [Fact]
        public void GetCardValueOfTwo_ReturnsExpectedCard()
        {
            try
            {
                Assert.Equal("2", ValueOfCards.Two);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }
        [Fact]
        public void GetCardValueOfThree_ReturnsExpectedCard()
        {
            try
            {
                Assert.Equal("3", ValueOfCards.Three);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }
        [Fact]
        public void GetCardValueOfFour_ReturnsExpectedCard()
        {
            try
            {
                Assert.Equal("4", ValueOfCards.Four);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }
        [Fact]
        public void GetCardValueOfFive_ReturnsExpectedCard()
        {
            try
            {
                Assert.Equal("5", ValueOfCards.Five);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }
        [Fact]
        public void GetCardValueOfSix_ReturnsExpectedCard()
        {
            try
            {
                Assert.Equal("6", ValueOfCards.Six);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }
        [Fact]
        public void GetCardValueOfSeven_ReturnsExpectedCard()
        {
            try
            {
                Assert.Equal("7", ValueOfCards.Seven);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }
        [Fact]
        public void GetCardValueOfEight_ReturnsExpectedCard()
        {
            try
            {
                Assert.Equal("8", ValueOfCards.Eight);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }
        [Fact]
        public void GetCardValueOfNine_ReturnsExpectedCard()
        {
            try
            {
                Assert.Equal("9", ValueOfCards.Nine);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }
        [Fact]
        public void GetCardValueOfTen_ReturnsExpectedCard()
        {
            try
            {
                Assert.Equal("10", ValueOfCards.Ten);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }
        [Fact]
        public void GetCardValueOfJack_ReturnsExpectedCard()
        {
            try
            {
                Assert.Equal("j", ValueOfCards.Jack);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }
        [Fact]
        public void GetCardValueOfQueen_ReturnsExpectedCard()
        {
            try
            {
                Assert.Equal("q", ValueOfCards.Queen);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }
        [Fact]
        public void GetCardValueOfKing_ReturnsExpectedCard()
        {
            try
            {
                Assert.Equal("k", ValueOfCards.King);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }
        [Fact]
        public void GetCardValueOfAce_ReturnsExpectedCard()
        {
            try
            {
                Assert.Equal("a", ValueOfCards.Ace);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }

        [Fact]
        public void ValueOfCardsContains_CardThatIsContainedInValueOfCards_ReturnsTrue()
        {
            try
            {
                Assert.True(ValueOfCards.Contains(ValueOfCards.Ace));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }

        [Fact]
        public void ValueOfCardsContains_CardThatIsNotContainedInValueOfCards_ReturnsFalse()
        {
            try
            {
                Assert.False(ValueOfCards.Contains("~"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }

        [Fact]
        public void GetCardName_ValidCardValue_ReturnsExpectedCardName()
        {
            try
            {
                Assert.Equal("Ace",ValueOfCards.GetCardName(ValueOfCards.Ace));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }

        [Fact]
        public void GetCardName_InvalidCardValue_ReturnsExpectedCardNameNotFound()
        {
            try
            {
                Assert.Equal(string.Empty, ValueOfCards.GetCardName("~"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }

        [Fact]
        public void GetCardValueByPropName_ValidCardName_ReturnsExpectedCardNameNotFound()
        {
            try
            {
                Assert.Equal(ValueOfCards.Ace, ValueOfCards.GetCardValueByPropName("Ace"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }

        [Fact]
        public void GetCardValueByPropName_InvalidCardName_ReturnsExpectedCardNameNotFound()
        {
            try
            {
                Assert.Equal(string.Empty, ValueOfCards.GetCardValueByPropName("~"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }

        [Fact]
        public void GetAllCardValues_ReturnsExpectedCardValues()
        {
            try
            {
                List<string> expected = new List<string>()
                {
                    "2",
                    "3",
                    "4",
                    "5",
                    "6",
                    "7",
                    "8",
                    "9",
                    "10",
                    "j",
                    "q",
                    "k",
                    "a"
                };

                Assert.Equal(expected, ValueOfCards.GetAllCardValues());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }
    }
}
