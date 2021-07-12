using System;
using System.Collections.Generic;
using System.Text;

namespace CardSort
{
    public interface ICard
    {
        public string ToString();
        public int GetCardFace();
        public string GetSuit();
    }
}
