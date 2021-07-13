using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CardSort
{
    public class Helper
    {
        public void Play()
        {
            List<string> tempCardList = GetUserInput();

            if(tempCardList.Count>0)
            {
                IDeck deckOfCards = new Deck(CreateListOfCards(tempCardList));
                deckOfCards.Sort();
                Console.WriteLine(deckOfCards.ToString());
            }
        }

        public List<string> GetUserInput(string test=null)
        {
            string cardsToSeperate;

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
                cardsToSeperate = test;

            cardsToSeperate = cardsToSeperate.Replace(" ", string.Empty);
            cardsToSeperate = cardsToSeperate.ToLower();
            if(ValidInputCheck(cardsToSeperate.Split(',').ToList()))
                return cardsToSeperate.Split(',').ToList();
            return new List<string>();
        }

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
                        //The card only has a length of 2 so it must have a card value of 1-9 or j, q, k, or a if not then it is not a valid card
                        if (element[0] == '1' || element[0] == '2' || element[0] == '3' || element[0] == '4' || element[0] == '5' ||
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
                            Console.WriteLine("ERROR: The value for a card must be one of the following: 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K, A" +
                                    "\nCard that caused the error: " + element.ToString());
                    }

                    return false;
                }
                else
                {
                    //Telling the user that the element that caused the error was an empty string was not helpful so had to had logic to tell them they need to have at least 1 card instead
                    if (element == "")
                    {
                        Console.WriteLine("ERROR: A deck of cards has to have at least 1 card in it!");
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

        public IList<ICard> CreateListOfCards(List<string> tempCardList)
        {
            IList<ICard> listOfCards = new List<ICard>();

            foreach (string card in tempCardList)
            {
                if (!Int32.TryParse(card[0].ToString(), out int num))
                {
                    if (card[0] == 'j')
                        listOfCards.Add(new Card(11, card[1].ToString()));
                    if (card[0] == 'q')
                        listOfCards.Add(new Card(12, card[1].ToString()));
                    if (card[0] == 'k')
                        listOfCards.Add(new Card(13, card[1].ToString()));
                    if (card[0] == 'a')
                        listOfCards.Add(new Card(14, card[1].ToString()));
                    continue;
                }

                if (card.Length == 2)
                    listOfCards.Add(new Card(Int32.Parse(card[0].ToString(), NumberStyles.Integer), card[1].ToString()));
                if (card.Length == 3) //The face value of the card is 10
                    listOfCards.Add(new Card(Int32.Parse(card[0].ToString() + card[1].ToString(), NumberStyles.Integer), card[2].ToString()));
            }

            return listOfCards;
        }
    }
}
