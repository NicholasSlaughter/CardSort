using System;
using System.Collections.Generic;
using System.Text;

namespace CardSort
{
    //A Card class that holds the value and suit of a card
    public class Card : ICard
    {
        public string Value { get; set; }
        public CardSuit Suit { get; set; }
        public Card(string cardValue, CardSuit suit)
        {
            //Cards can only have a value between 1 and 15 (2-Ace)
            if (ValueOfCards.Contains(cardValue))
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
            return Value.ToUpper() + (char)Suit;
        }

        public string GetCardValue()
        {
            return Value;
        }

        public string GetCardValueName()
        {
            if(ValueOfCards.GetCardName(Value) != "")
                return ValueOfCards.GetCardName(Value);
            throw new Exception("Card Value Was Not Associated With A Card Name");
        }

        public CardSuit GetSuit()
        {
            return Suit;
        }
    }
}
