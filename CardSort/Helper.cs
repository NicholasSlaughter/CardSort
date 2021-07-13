using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CardSort
{
    //Helper class that essentially runs the program. Allows a user to input their deck of cards and then outputs the sorted list
    public class Helper
    {
        //Runs the program in the correct order from getting a users input, to checking if the input is correct, and outputting the correct order of the deck
        public void Play()
        {
            List<string> tempCardList = new List<string>();
            string continu = "a";
            string response;

            //The program will continue to run untill the user wants to end the program
            while (continu[0] != 'n')
            {
                //Set the users input as a list of strings
                tempCardList = GetUserInput();

                //If the users input is greater than 1 than the input was valid and we sort the deck
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
        public List<string> GetUserInput(string test=null)
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
        private bool ValidInputCheck(List<string> inputList)
        {
            //Check all of the elements in the list to see if they are valid
            foreach (string element in inputList)
            {
                //A valid card is at least 2 characters and at most 3 characters
                if (element.Length > 1 && element.Length < 4)
                {
                    //If the card has a length of 3 then it must have a card value of 10 if not then it is invalid
                    if (element.Length == 3)
                    {
                        if (element[0] == '1' && element[1] == '0')
                        {
                            if (element[2] == 'd' || element[2] == 's' || element[2] == 'c' || element[2] == 'h') //Cards must have a suit that is specified by d, s, c, or h
                            {
                                continue;
                            }
                            else
                                Console.WriteLine("ERROR: cards can only have the following characters for a suit: d, s, c, h" +
                                "\nCard that caused the error: " + element.ToString());
                        }
                        else
                            Console.WriteLine("ERROR: The only accepted card value for a card that is 3 characters long is 10 (Jack, Queen, King, Ace must be typed as the following: J, Q, K, A)" +
                                "\nCard that caused the error: " + element.ToString());
                    }
                    else
                    {
                        //The card only has a length of 2 so it must have a card value of 1-9, j, q, k, or a if not then it is not a valid card
                        if (element[0] == '2' || element[0] == '3' || element[0] == '4' || element[0] == '5' ||
                            element[0] == '6' || element[0] == '7' || element[0] == '8' || element[0] == '9' ||
                            element[0] == 'j' || element[0] == 'q' || element[0] == 'k' || element[0] == 'a')
                        {
                            if (element[1] == 'd' || element[1] == 's' || element[1] == 'c' || element[1] == 'h') //Cards must have a suit that is specified by d, s, c, or h
                            {
                                continue;
                            }
                            else
                                Console.WriteLine("ERROR: cards can only have the following characters for a suit: d, s, c, h" +
                                    "\nCard that caused the error: " + element.ToString());
                        }
                        else
                            Console.WriteLine("ERROR: The value for a card must be one of the following: 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K, A" +
                                    "\nCard that caused the error: " + element.ToString());
                    }

                    return false; //If the program makes it here then a card did not meet the criteria of what makes a valid card and we return false
                }
                else
                {
                    //A card was either and empty string or it had more than 3 characters so let the user know of the error and return false
                    if (element == "")
                    {
                        Console.WriteLine("ERROR: A card has to have a value and a suit");
                        Console.WriteLine("Example Cards: 3c, Js, 2d, 10h, Kh, 8s, Ac, 4h");
                    }
                    else
                    {
                        Console.WriteLine("ERROR: Cards can only be specified by 2 - 3 characters!");
                        Console.WriteLine("Example Cards: 3c, Js, 2d, 10h, Kh, 8s, Ac, 4h");
                        Console.WriteLine("Card that caused the error: " + element.ToString());
                    }
                    return false;
                }
            }

            //If the program makes it here then all of the elements in the list were valid
            return true;
        }

        //Creates a list of Card objects from the list of cards in a string
        public IList<ICard> CreateListOfCards(List<string> tempCardList)
        {
            IList<ICard> listOfCards = new List<ICard>();

            //foreach card in the temporary card list make a card object and add it to the list of cards
            foreach (string card in tempCardList)
            {
                //If a card value is j, q, k, or a then we need to set its value to 11-14 which helps with the sorting of the cards
                if (!Int32.TryParse(card[0].ToString(), out int num))
                {
                    if (card[0] == 'j')
                        listOfCards.Add(new Card(CardValue.Jack, (CardSuit)card[1]));
                    if (card[0] == 'q')
                        listOfCards.Add(new Card(CardValue.Queen, (CardSuit)card[1]));
                    if (card[0] == 'k')
                        listOfCards.Add(new Card(CardValue.King, (CardSuit)card[1]));
                    if (card[0] == 'a')
                        listOfCards.Add(new Card(CardValue.Ace, (CardSuit)card[1]));
                    continue;
                }

                if (card.Length == 2)
                    listOfCards.Add(new Card((CardValue)Int32.Parse(card[0].ToString(), NumberStyles.Integer), (CardSuit)card[1]));
                if (card.Length == 3) //The face value of the card is 10
                    listOfCards.Add(new Card((CardValue)Int32.Parse(card[0].ToString() + card[1].ToString(), NumberStyles.Integer), (CardSuit)card[2]));
            }

            return listOfCards; //Successfully created a list of card objects from the cards a user entered
        }
    }
}
