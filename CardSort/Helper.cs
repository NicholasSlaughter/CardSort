using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CardSort
{
    //Helper class that essentially runs the program. Allows a user to input their deck of cards and then outputs the sorted list
    public static class Helper
    {

        //Runs the program in the correct order from getting a users input, to checking if the input is correct, and outputting the correct order of the deck
        public static void Play()
        {
            List<string> tempCardList = new List<string>();
            string continu = "a";
            string response;

            //The program will continue to run untill the user wants to end the program
            while (continu[0] != 'n')
            {
                //Set the users input as a list of strings
                tempCardList = GetUserInput();

                //If the users input is greater than 1 coming out of GetUserInput() than the input was valid and we sort the deck
                if (tempCardList.Count>0)
                {
                    IDeck deckOfCards = new Deck(CreateListOfCards(tempCardList));
                    deckOfCards.Sort();
                    Console.WriteLine("Your Sorted Deck of Cards:\n" + deckOfCards.ToString());
                }

                //Check to see if the user wants to sort another deck of cards
                response = "a";
                while (response != "g")
                {
                    Console.Write("Would you like to sort another deck of cards? (Y/N): ");
                    response = Console.ReadLine().ToLower();
                    if (response[0] == 'y' || response[0] == 'n')
                    {
                        //If the user input a valid response then set continue to either y or n and exit the nested while loop
                        continu = response;
                        response = "g";
                        if (continu[0] == 'y')
                            Console.WriteLine(""); //Seperates previous card sorts by a new line space
                    }
                    else
                        Console.WriteLine("ERROR: You can only enter Y or N for your response!"); //If the user input any other string that does not start with y or n then tell the user and prompt them to enter an answer again
                }
            }
        }

        //Gets the users deck of cards and returns it as a list of cards. If the program is being ran as a unit test then a test string of cards will be used instead of user input
        public static List<string> GetUserInput(string test=null)
        {
            string cardsToSeperate;

            //If the application is running and we are not unit testing then we take input from the console window
            if (test==null)
            {
                Console.WriteLine("Welcome to Card Sort");
                Console.WriteLine("This programming will allow you to input a list of cards and sort them from lowest card face to highest card face going in order of diamonds, spades, clubs, and hearts");
                Console.WriteLine("Please enter cards by face value followed by suit and seperated by a comma");
                Console.WriteLine("Example: 3c, Js, 2d, 10h, Kh, 8s, Ac, 4h");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
                Console.Write("Please enter the list of cards you want sorted: ");

                cardsToSeperate = Console.ReadLine();
            }
            else
                cardsToSeperate = test; //If we are testing then set the variable to what string of cards we want to test

            //Get rid of white spaces and make all characters lower case in the string
            cardsToSeperate = cardsToSeperate.Replace(" ", string.Empty);
            cardsToSeperate = cardsToSeperate.ToLower();

            //If all of the cards entered are valid then return a list of the cards
            if(ValidInputCheck(cardsToSeperate.Split(',').ToList()))
                return cardsToSeperate.Split(',').ToList();
            return new List<string>(); //If the program makes it here then there was an invalid card
        }

        //Checks to see if the cards entered are all valid cards
        private static bool ValidInputCheck(List<string> inputList)
        {
            //Check all of the elements in the list to see if they are valid
            foreach (string card in inputList)
            {
                //A valid card is at least 2 characters and at most 3 characters
                if (card.Length > 1 && card.Length < 4)
                {
                    //Check to see if the last character in the card is a valid card suit
                    if (Enum.IsDefined(typeof(CardSuit), (int)card[^1]))
                    {
                        //need to check if all but the last character in the card is a valid card value
                        if (ValueOfCards.Contains(card.Remove(card.Length - 1, 1)))
                            continue; //Valid card so continue to the next card in the list
                        else
                            Console.WriteLine(GetListOfValidCardsForErrors(card, "Value")); //Output all valid Card Values from ValueOfCards class

                        return false; //If the program makes it here then a card did not meet the criteria of what makes a valid card and we return false
                    }
                    else
                    {
                        //Output all valid suits from CardSuit enum
                        Console.WriteLine(GetListOfValidCardsForErrors(card, "Suit"));

                        Console.WriteLine("Not Valid Cards: c3, d10, 1s0");
                        Console.WriteLine("Valid Cards: 3c, Js, 2d, 10h, Kh, 8s, Ac, 4h");
                        Console.WriteLine("Card that caused the error: " + card);
                        return false;
                    }
                }
                else
                {
                    //A card was either an empty string or it had more than 3 characters so let the user know of the error and return false
                    if (card == "")
                    {
                        Console.WriteLine("ERROR: A card has to have a value and a suit");
                        Console.WriteLine("Example Cards: 3c, Js, 2d, 10h, Kh, 8s, Ac, 4h");
                    }
                    else
                    {
                        Console.WriteLine("ERROR: Cards can only be specified by 2 - 3 characters!");
                        Console.WriteLine("Example Cards: 3c, Js, 2d, 10h, Kh, 8s, Ac, 4h");
                        Console.WriteLine("Card that caused the error: " + card);
                    }
                    return false;
                }
            }

            //If the program makes it here then all of the elements in the list were valid
            return true;
        }

        //Creates a list of Card objects from the string list of cards
        public static IList<ICard> CreateListOfCards(List<string> tempCardList)
        {
            IList<ICard> listOfCards = new List<ICard>();

            //foreach card in the temporary card list make a Card object and add it to the list of Card objects
            foreach (string card in tempCardList)
            {
                string value = card.Remove(card.Length - 1, 1);
                char suit = card[^1];
                //If a card value is j, q, k, or a then we need to set its value to 11-14 which helps with the sorting of the cards
                if (!Int32.TryParse(value, out int num))
                {
                    listOfCards.Add(new Card(value, (CardSuit)suit)); //Need to figure out to get card value without indexing array
                    continue;
                }

                if (card.Length == 2)
                    listOfCards.Add(new Card(value, (CardSuit)suit));
                if (card.Length == 3) //The face value of the card is 10
                    listOfCards.Add(new Card(value, (CardSuit)suit));
            }

            return listOfCards; //Successfully created a list of card objects from the cards a user entered
        }

        //Returns the proper error containing all of the valid versions of the error
        public static string GetListOfValidCardsForErrors(string card, string partOfCardToCheck)
        {
            StringBuilder sb = new StringBuilder();
            if (partOfCardToCheck == "Value")
            {
                //Return all valid card values
                sb.Append("ERROR: Card value must be one of the following cards: ");
                foreach (string cardValue in ValueOfCards.GetAllCardValues())
                    sb.Append($"{cardValue.ToUpper()}, ");
                sb.Remove(sb.Length - 2, 2);
                sb.Append($"\nCard that caused Error: {card}");
                return sb.ToString();
            }
            if(partOfCardToCheck == "Suit")
            {
                //Return all valid suits from CardSuit enum
                sb.Append("ERROR: The suit of the card can only be specified after the value of the card has been give and is one of the following letters: ");
                foreach (int i in Enum.GetValues(typeof(CardSuit)))
                    sb.Append($"{(char)i}, ");
                sb.Remove(sb.Length - 2, 2);
                return sb.ToString();
            }
            return "ERROR: Not Valid Input For CreateListOfCards";
        }
    }
}
