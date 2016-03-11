using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.app
{
    class Cards
    {
        public class Card
        {
            public Deck.Suit Suit { get; set; }
            public Deck.Rank Rank { get; set; }
            public int Value { get; set; }
        }
    }
}
