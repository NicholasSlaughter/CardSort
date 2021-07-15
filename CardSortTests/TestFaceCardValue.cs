using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CardSort;

namespace CardSortTests
{
    //Tests the functionality of the Value Of Cards class
    public class TestFaceCardValue
    {
        [Fact]
        public void GetNumericalValueOfJack_ReturnsExpectedCardValue()
        {
            try
            {
                Assert.Equal(11, FaceCardValue.Jack);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }
        [Fact]
        public void GetNumericalValueOfQueen_ReturnsExpectedCardValue()
        {
            try
            {
                Assert.Equal(12, FaceCardValue.Queen);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }
        [Fact]
        public void GetNumericalValueOfKing_ReturnsExpectedCardValue()
        {
            try
            {
                Assert.Equal(13, FaceCardValue.King);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }
        [Fact]
        public void GetNumericalValueOfAce_ReturnsExpectedCardValue()
        {
            try
            {
                Assert.Equal(14, FaceCardValue.Ace);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }

        [Fact]
        public void FaceCardValueContains_CardThatIsContainedInFaceCardValue_ReturnsTrue()
        {
            try
            {
                Assert.True(FaceCardValue.Contains(FaceCardValue.Ace.ToString()));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }

        [Fact]
        public void FaceCardValueContains_CardThatIsNotContainedInFaceCardValue_ReturnsFalse()
        {
            try
            {
                Assert.False(FaceCardValue.Contains("~"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }

        [Fact]
        public void GetFaceCardName_ValidCardValue_ReturnsExpectedCardName()
        {
            try
            {
                Assert.Equal("Ace", FaceCardValue.GetCardName(FaceCardValue.Ace.ToString()));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }

        [Fact]
        public void GetFaceCardName_InvalidCardValue_ReturnsExpectedCardNameNotFound()
        {
            try
            {
                Assert.Equal(string.Empty, FaceCardValue.GetCardName("~"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }

        [Fact]
        public void GetFaceCardValueByPropName_ValidCardName_ReturnsExpectedCardNameNotFound()
        {
            try
            {
                Assert.Equal(FaceCardValue.Ace, FaceCardValue.GetCardValueByPropName("Ace"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }

        [Fact]
        public void GetFaceCardValueByPropName_InvalidCardName_ReturnsExpectedCardNameNotFound()
        {
            try
            {
                Assert.Equal(-1, FaceCardValue.GetCardValueByPropName("~"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }
    }
}
