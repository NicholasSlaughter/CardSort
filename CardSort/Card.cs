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
            //Cards can only have a valid card value
            if (ValueOfCards.Contains(cardValue))
                this.Value = cardValue;
            else
                throw new ArgumentException("Card did not have a valid card value",nameof(cardValue));

            //Cards can only have valid card suits
            if (Enum.IsDefined(typeof(CardSuit),suit))
                this.Suit = suit;
            else
                throw new ArgumentException("Card did not have a valid card suit", nameof(suit));
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
