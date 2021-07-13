using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardSort
{
    public class Deck : IDeck
    {
        public IList<ICard> Cards { get; set; }

        public Deck(IList<ICard> cards)
        {
            if (cards.Count() == 0)
                throw new ArgumentException("There needs to be at least 1 card in the deck", nameof(cards));
            this.Cards = cards;
        }

        public override string ToString()
        {
            //Build a string that will represent how the deck of cards will be output to the console window
            StringBuilder sb = new StringBuilder();

            //For each card in cards append a card to the string builder
            foreach (Card card in Cards)
            {
                //If the value is above 10 then we need to add change its value to J, Q, K, or A to because that is the proper output. EX: 11d becomes Jd
                if (card.GetCardValue() > 10)
                {
                    if (card.GetCardValue() == 11)
                        sb.Append("J" + card.GetSuit());
                    if (card.GetCardValue() == 12)
                        sb.Append("Q" + card.GetSuit());
                    if (card.GetCardValue() == 13)
                        sb.Append("K" + card.GetSuit());
                    if (card.GetCardValue() == 14)
                        sb.Append("A" + card.GetSuit());
                    sb.Append("\n"); //Add a new line because it looks nicer when every card is on a new line
                    continue; //If the card value was above 10 then we already added the card to the string builder so we want to continue to the next card in the list
                }
                sb.Append(card.ToString()); //Add the card to the string builder
                sb.Append("\n");
            }
            return sb.ToString(); //The proper output string has been built so return
        }

        public void Sort()
        {
            IEnumerable<ICard> sortedListOfCards = Cards.OrderBy(p => p.GetSuit()).ThenBy(p => p.GetCardValue()); //Order the list of Cards by suit and then buy card value
            IList<ICard> deckOfCards = sortedListOfCards.ToList();
            IList<ICard> listOfDiamonds = new List<ICard>(); //OrderBy does not order the suit to how the program should work so we need to make temp lists for all of the suit of cards to go into
            IList<ICard> listOfSpades = new List<ICard>();
            IList<ICard> listOfClubs = new List<ICard>();
            IList<ICard> listOfHearts = new List<ICard>();

            //For each card in the deck of cards add a card to the list of its suit
            foreach (Card card in deckOfCards)
            {
                if (card.GetSuit() == "d")
                    listOfDiamonds.Add(card);
                if (card.GetSuit() == "s")
                    listOfSpades.Add(card);
                if (card.GetSuit() == "c")
                    listOfClubs.Add(card);
                if (card.GetSuit() == "h")
                    listOfHearts.Add(card);
            }

            //Clear the deck of cards and then add to the deck of cards in order of the proper order the program should have i.e. diamonds, spades, clubs, hearts
            deckOfCards.Clear();
            ((List<ICard>)deckOfCards).AddRange(listOfDiamonds);
            ((List<ICard>)deckOfCards).AddRange(listOfSpades);
            ((List<ICard>)deckOfCards).AddRange(listOfClubs);
            ((List<ICard>)deckOfCards).AddRange(listOfHearts);

            Cards = deckOfCards; //Set the list of Cards to the ordered deck of cards
        }
    }
}
