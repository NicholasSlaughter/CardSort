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
            StringBuilder sb = new StringBuilder();

            foreach (Card card in Cards)
            {
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
                    sb.Append("\n\n");
                    continue;
                }
                sb.Append(card.ToString());
                sb.Append("\n\n");
            }

            sb.Remove(sb.Length - 2, 2);
            return sb.ToString();
        }

        public void Sort()
        {
            IEnumerable<ICard> sortedListOfCards = Cards.OrderBy(p => p.GetSuit()).ThenBy(p => p.GetCardValue());
            IList<ICard> deckOfCards = sortedListOfCards.ToList();
            IList<ICard> listOfDiamonds = new List<ICard>();
            IList<ICard> listOfSpades = new List<ICard>();
            IList<ICard> listOfClubs = new List<ICard>();
            IList<ICard> listOfHearts = new List<ICard>();

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

            deckOfCards.Clear();
            ((List<ICard>)deckOfCards).AddRange(listOfDiamonds);
            ((List<ICard>)deckOfCards).AddRange(listOfSpades);
            ((List<ICard>)deckOfCards).AddRange(listOfClubs);
            ((List<ICard>)deckOfCards).AddRange(listOfHearts);

            Cards = deckOfCards;
        }
    }
}
