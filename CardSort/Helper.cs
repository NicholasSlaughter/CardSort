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
            IList<ICard> needsName = new List<ICard>();
            string cardsToSeperate;

            Console.WriteLine("Welcome to Card Sort");
            Console.WriteLine("This programming will allow you to input a list of cards and sort them from lowest card face to highest card face going in order of diamonds, spades, clubs, and hearts");
            Console.WriteLine("Please enter cards by face value followed by suit and seperated by a comma");
            Console.WriteLine("Example: 3c, Js, 2d, 10h, Kh, 8s, Ac, 4h");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
            Console.Write("Please enter the list of cards you want sorted: ");

            cardsToSeperate = Console.ReadLine();
            cardsToSeperate = cardsToSeperate.Replace(" ", string.Empty);
            cardsToSeperate = cardsToSeperate.ToLower();
            List<string> cardList = cardsToSeperate.Split(',').ToList();
            
            foreach (string card in cardList)
            {
                if (!Int32.TryParse(card[0].ToString(), out int num))
                {
                    if (card[0] == 'j')
                        needsName.Add(new Card(11, card[1].ToString()));
                    if (card[0] == 'q')
                        needsName.Add(new Card(12, card[1].ToString()));
                    if (card[0] == 'k')
                        needsName.Add(new Card(13, card[1].ToString()));
                    if (card[0] == 'a')
                        needsName.Add(new Card(14, card[1].ToString()));
                    continue;
                }

                if (card.Length == 2)
                    needsName.Add(new Card(Int32.Parse(card[0].ToString(), NumberStyles.Integer), card[1].ToString()));
                if (card.Length == 3) //The face value of the card is 10
                    needsName.Add(new Card(Int32.Parse(card[0].ToString() + card[1].ToString(), NumberStyles.Integer), card[2].ToString()));
            }

            IDeck deckOfCards = new Deck(needsName);
            deckOfCards.Sort();
            Console.WriteLine(deckOfCards.ToString());
        }
    }
}
