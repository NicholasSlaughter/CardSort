using System;
using System.Collections.Generic;
using System.Text;

namespace CardSort
{
    public interface IDeck
    {
        public IList<ICard> Cards { get; }
        public void Sort();
        public string ToString();
    }
}
