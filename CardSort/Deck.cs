using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardSort
{
    //A deck of cards class that holds a list of cards and allows for the list of cards to be sorted
    public class Deck : IDeck
    {
        public IList<ICard> Cards { get; set; }

        public Deck(IList<ICard> cards)
        {
            if (cards.Count() == 0)
                throw new ArgumentException("There needs to be at least 1 card in the deck", nameof(cards));
            this.Cards = cards;
        }

        //The string representation of the deck of cards needs to be valid with the requirements for the program
        public override string ToString()
        {
            //Build a string that will represent how the deck of cards should look as a string
            StringBuilder sb = new StringBuilder();

            //For each card in cards append a card to the string builder
            foreach (Card card in Cards)
            {
                sb.Append(card.ToString() + " - " + card.GetCardValueName() + " of " + card.GetSuit()); //Add the card to the string builder
                sb.Append("\n");
            }
            return sb.ToString(); //The proper output string has been built so return
        }

        //The deck of cards needs to be sorted in a specific way. Sorted by the following suit order diamonds, spades, clubs, hearts and then ordered from lowest to highest card value (2-Ace)
        public void Sort()
        {
            var tempCards = Cards;
            Dictionary<string, int> faceCardValueConversion = new Dictionary<string, int>();

            //Need to go through each card in the deck and replace the face cards with integer values to make sorting easier
            foreach(Card card in tempCards)
            {
                if(!int.TryParse(card.GetCardValue(),out int result))
                {
                    int numValue = FaceCardValue.GetCardValueByPropName(card.GetCardValueName());

                    //If there is a face card that is equivalent to a number card we need to be able to only convert the exact occurance of that face card back to normal and leave the number cards alone
                    if (!faceCardValueConversion.ContainsKey(card.ToString()))
                        faceCardValueConversion.Add(card.ToString(), 0);
                    faceCardValueConversion[card.ToString()] += 1; //Increment the occurance of the face card by 1

                    card.Value = numValue.ToString();
                }
            }

            IEnumerable<ICard> sortedListOfCards = tempCards.OrderBy(p => p.GetSuit()).ThenBy(p => Int32.Parse(p.GetCardValue())); //Order the list of Cards by suit and then buy card value
            IList<ICard> deckOfCards = sortedListOfCards.ToList();
            IList<ICard> listOfDiamonds = new List<ICard>(); //OrderBy does not order the suit to how the program should work so we need to make temp lists for all of the suit of cards to go into
            IList<ICard> listOfSpades = new List<ICard>();
            IList<ICard> listOfClubs = new List<ICard>();
            IList<ICard> listOfHearts = new List<ICard>();

            //For each card in the deck of cards add a card to the list of its suit
            foreach (Card card in deckOfCards)
            {
                if (card.GetSuit() == CardSuit.Diamonds)
                    listOfDiamonds.Add(GetProperCardValue(card, faceCardValueConversion));
                if (card.GetSuit() == CardSuit.Spades)
                    listOfSpades.Add(GetProperCardValue(card, faceCardValueConversion));
                if (card.GetSuit() == CardSuit.Clubs)
                    listOfClubs.Add(GetProperCardValue(card, faceCardValueConversion));
                if (card.GetSuit() == CardSuit.Hearts)
                    listOfHearts.Add(GetProperCardValue(card, faceCardValueConversion));
            }

            //Clear the deck of cards and then add to the deck of cards in order of the proper order the program should have i.e. diamonds, spades, clubs, hearts
            deckOfCards.Clear();
            ((List<ICard>)deckOfCards).AddRange(listOfDiamonds);
            ((List<ICard>)deckOfCards).AddRange(listOfSpades);
            ((List<ICard>)deckOfCards).AddRange(listOfClubs);
            ((List<ICard>)deckOfCards).AddRange(listOfHearts);

            Cards = deckOfCards; //Set the list of Cards to the ordered deck of cards
        }

        //If a card is a face card return with its proper card value (letter)
        private Card GetProperCardValue(Card card, Dictionary<string, int> faceCardValueConversion)
        {
            //See if the card value matches the value of a face card
            if (FaceCardValue.Contains(card.Value))
            {
                //Get all occurances of face cards that have the same suit to as the card passed in
                var listOfMatchSuits = faceCardValueConversion.Keys.Where(c => c[^1].Equals((char)card.Suit));
                foreach (string i in listOfMatchSuits)
                {
                    string cardValue = i.Remove(i.Length - 1, 1).ToLower();
                    var faceCardValue = FaceCardValue.GetCardValueByPropName(ValueOfCards.GetCardName(cardValue)).ToString();
                    //If the cards value matches a Face Card Value then replace that card with its proper value (letter)
                    if (card.Value == faceCardValue)
                    {
                        //If the occurance of that card is not zero then we still need to convert that card back to normal
                        if (faceCardValueConversion[i] != 0)
                        {
                            faceCardValueConversion[i] -= 1; //Reduce the occurance of that face card
                            card.Value = cardValue;//Replace face card integer value with string value. Ex: 11d -> jd
                            return card;
                        }
                    }
                }
            }
            return card;
        }
    }
}
