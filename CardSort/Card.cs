using System;
using System.Collections.Generic;
using System.Text;

namespace CardSort
{
    //A Card class that holds the value and suit of a card
    public class Card : ICard
    {
        public CardValue Value { get; private set; }
        public CardSuit Suit { get; private set; }
        public Card(CardValue cardValue, CardSuit suit)
        {
            //Cards can only have a value between 2 and 14 (2-Ace)
            if ((int)cardValue > 1 && (int)cardValue < 15)
            this.Value = cardValue;
            else
                throw new ArgumentException("The card value must be one of the following: 2,3,4,5,6,7,8,9,10,J,Q,K,A",nameof(cardValue));

            //Cards can only have their suit specified by d, s, c, or h
            if (suit == CardSuit.Diamonds || suit == CardSuit.Spades || suit == CardSuit.Clubs || suit == CardSuit.Hearts)
                this.Suit = suit;
            else
                throw new ArgumentException("The card suit must be one of the following: d,s,c,h", nameof(suit));
        }

        public override string ToString()
        {
            int cardValueAsInt = (int)Value;
            return cardValueAsInt.ToString() + (char)Suit;
        }

        public CardValue GetCardValue()
        {
            return Value;
        }

        public CardSuit GetSuit()
        {
            return Suit;
        }
    }
}
