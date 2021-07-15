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

            //Need to go through each card in the deck and replace the face cards with integer values to make sorting easier
            foreach(Card card in tempCards)
            {
                if(!int.TryParse(card.GetCardValue(),out int result))
                {
                    int numValue = (int)Enum.Parse(typeof(FaceCardValue), card.GetCardValueName());
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
            //TODO: Reduce redundence
            foreach (Card card in deckOfCards)
            {
                if (card.GetSuit() == CardSuit.Diamonds)
                    listOfDiamonds.Add(GetProperCardValues(card)); //Card is not face card so add the card to the list of diamonds immediately
                if (card.GetSuit() == CardSuit.Spades)
                    listOfSpades.Add(GetProperCardValues(card));
                if (card.GetSuit() == CardSuit.Clubs)
                    listOfClubs.Add(GetProperCardValues(card));
                if (card.GetSuit() == CardSuit.Hearts)
                    listOfHearts.Add(GetProperCardValues(card));
            }

            //Clear the deck of cards and then add to the deck of cards in order of the proper order the program should have i.e. diamonds, spades, clubs, hearts
            deckOfCards.Clear();
            ((List<ICard>)deckOfCards).AddRange(listOfDiamonds);
            ((List<ICard>)deckOfCards).AddRange(listOfSpades);
            ((List<ICard>)deckOfCards).AddRange(listOfClubs);
            ((List<ICard>)deckOfCards).AddRange(listOfHearts);

            Cards = deckOfCards; //Set the list of Cards to the ordered deck of cards
        }

        private Card GetProperCardValues(Card card)
        {
            if (Enum.IsDefined(typeof(FaceCardValue), Int32.Parse(card.GetCardValue()))) //See if card is a face card given a face card value
            {
                string faceCardToRetrieve = Enum.Parse(typeof(FaceCardValue), card.GetCardValue()).ToString();
                card.Value = ValueOfCards.GetCardValueByPropName(faceCardToRetrieve); //Replace face card integer value with string value. Ex: 11d -> jd
                return card;
            }
            return card;
        }
    }
}
