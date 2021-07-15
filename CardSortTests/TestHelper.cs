using System;
using Xunit;
using CardSort;
using System.Collections.Generic;

namespace CardSortTests
{
    //Tests the functionality of the Helper class
    public class TestHelper
    {
        [Fact]
        public void GetUserInput_EnterValidInput_ReturnsExpectedListOfCards()
        {
            try
            {
                string testInput = "3c, Js, 2d, 10h, Kh, 8s, Ac, 4h";

                List<string> cardList = Helper.GetUserInput(testInput);
                List<string> expectedCardList = new List<string>(){
                    "3c",
                    "js",
                    "2d",
                    "10h",
                    "kh",
                    "8s",
                    "ac",
                    "4h",
                };

                Assert.Equal(expectedCardList, cardList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }
        [Fact]
        public void GetUserInput_EnterInValidInput_EmptyString_ReturnsInputNotValid()
        {
            try
            {
                string testInput = "";

                List<string> cardList = Helper.GetUserInput(testInput);
                List<string> expected = new List<string>();

                Assert.Equal(expected, cardList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }

        [Fact]
        public void GetUserInput_EnterInValidInput_LongerThan3Characters_ReturnsInputNotValid()
        {
            try
            {
                string testInput = "123d";

                List<string> cardList = Helper.GetUserInput(testInput);
                List<string> expected = new List<string>();

                Assert.Equal(expected, cardList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }

        [Fact]
        public void GetUserInput_EnterInValidInput_LessThan2Characters_ReturnsInputNotValid()
        {
            try
            {
                string testInput = "d";

                List<string> cardList = Helper.GetUserInput(testInput);
                List<string> expected = new List<string>();

                Assert.Equal(expected, cardList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }

        [Fact]
        public void GetUserInput_EnterInValidInput_InvalidThreeCharacterCard_ReturnsInputNotValid()
        {
            try
            {
                string testInput = "15d";

                List<string> cardList = Helper.GetUserInput(testInput);
                List<string> expected = new List<string>();

                Assert.Equal(expected, cardList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }
        [Fact]
        public void GetUserInput_EnterInValidInput_ValidThreeCharacterCard_InvalidSuit_ReturnsInputNotValid()
        {
            try
            {
                string testInput = "10b";

                List<string> cardList = Helper.GetUserInput(testInput);
                List<string> expected = new List<string>();

                Assert.Equal(expected, cardList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }
        [Fact]
        public void GetUserInput_EnterInValidInput_InValidTwoCharacterCard_ReturnsInputNotValid()
        {
            try
            {
                string testInput = "0d";

                List<string> cardList = Helper.GetUserInput(testInput);
                List<string> expected = new List<string>();

                Assert.Equal(expected, cardList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }

        [Fact]
        public void GetUserInput_EnterInValidInput_ValidTwoCharacterCard_InvalidSuit_ReturnsInputNotValid()
        {
            try
            {
                string testInput = "9b";

                List<string> cardList = Helper.GetUserInput(testInput);
                List<string> expected = new List<string>();

                Assert.Equal(expected, cardList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }

        [Fact]
        public void GetUserInput_EnterInValidInput_InValidTwoCharacterCard_LaterInList_ReturnsInputNotValid()
        {
            try
            {
                string testInput = "10s, 9b";

                List<string> cardList = Helper.GetUserInput(testInput);
                List<string> expected = new List<string>();

                Assert.Equal(expected, cardList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }

        [Fact]
        public void GetListOfValidCardsForErrors_ValueError_ReturnsString()
        {
            try
            {
                var tempCard = "2b";
                var validCardsToGet = "Value";
                var outputType = Helper.GetListOfValidCardsForErrors(tempCard, validCardsToGet).GetType().ToString();
                Assert.Equal("System.String", outputType);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }

        [Fact]
        public void GetListOfValidCardsForErrors_SuitError_ReturnsString()
        {
            try
            {
                var tempCard = "2b";
                var validCardsToGet = "Suit";
                var outputType = Helper.GetListOfValidCardsForErrors(tempCard, validCardsToGet).GetType().ToString();
                Assert.Equal("System.String", outputType);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }

        [Fact]
        public void GetListOfValidCardsForErrors_NotValidError_ReturnsString()
        {
            try
            {
                var tempCard = "2b";
                var validCardsToGet = "";
                var actual = Helper.GetListOfValidCardsForErrors(tempCard, validCardsToGet);
                Assert.Equal("ERROR: Not Valid Input For CreateListOfCards", actual);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.True(false);
            }
        }
    }
}
