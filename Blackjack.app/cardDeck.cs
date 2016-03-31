using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.app
{
    public class Deck : Stack<Card>
    {

        public Deck(IEnumerable<Card> cards) : base(cards)
        {
            
        }
        
        //Make deck
        //assign values to each card
        //figure out how to 

        public Card Deal()
        {

            return this.Pop();
        }

        public static Deck BuildDeck()
        {
            var cards = new List<Card>();

            foreach (Rank r in Enum.GetValues(typeof(Rank)))
            {
                foreach (Suit s in Enum.GetValues(typeof(Suit)))
                {
                    cards.Add(new Card(s, r));
                }
            }

            //sort the deck. NOTICE that the variable 'deck' is unchanged, but 'randomDeck' is the actual sorted deck.
            return new Deck(cards.OrderBy(x => Guid.NewGuid()).ToList());

        }
    }
}





