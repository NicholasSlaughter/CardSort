using System;
using System.Collections.Generic;
using System.Text;

namespace CardSort
{
    public class Card : ICard
    {
        public int CardValue { get; set; }
        public string Suit { get; set; }
        public Card(int cardValue, string suit)
        {
            //Cards can only have a value between 1 and 14 (1-Ace)
            if (cardValue > 0 && cardValue < 15)
                this.CardValue = cardValue;
            else
                throw new ArgumentException("The card value must be one of the following: 1,2,3,4,5,6,7,8,9,10,J,Q,K,A",nameof(cardValue));

            //Cards can only have their suit specified by d, s, c, or h
            if (suit == "d" || suit == "s" || suit == "c" || suit == "h")
                this.Suit = suit;
            else
                throw new ArgumentException("The card suit must be one of the following: d,s,c,h", nameof(suit));
        }

        public override string ToString()
        {
            return CardValue.ToString() + Suit;
        }

        public int GetCardValue()
        {
            return CardValue;
        }

        public string GetSuit()
        {
            return Suit;
        }
    }
}
