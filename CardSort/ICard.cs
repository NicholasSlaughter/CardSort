using System;
using System.Collections.Generic;
using System.Text;

namespace CardSort
{
    public interface ICard
    {
        public string ToString();
        public int GetCardValue();
        public string GetSuit();
    }
}
