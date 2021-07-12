using System;
using System.Collections.Generic;
using System.Text;

namespace CardSort
{
    class Card : ICard
    {
        public int CardFace { get; set; }
        public string Suit { get; set; }
        public Card(int cardFace, string suit)
        {
            this.CardFace = cardFace;
            this.Suit = suit;
        }

        public override string ToString()
        {
            return CardFace.ToString() + Suit;
        }

        public int GetCardFace()
        {
            return CardFace;
        }

        public string GetSuit()
        {
            return Suit;
        }
    }
}
