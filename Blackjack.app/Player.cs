using System.Collections.Generic;
using System.Linq;

namespace Blackjack.app
{
    public class Player : object
    {
        public List<Card> Hand { get; set; } = new List<Card>();

        public int HandTotal
        {
            get { return Hand.Sum(x => x.Value); }
        }

        public void AddToHand(Card card, bool isVisible = true)
        {
            card.IsVisible = isVisible;
            Hand.Add(card);
        }

        public override string ToString()
        {
            var result = "";
            foreach (var card in Hand)
            {
                result += card.ToString() + "\r\n";
            }
            return result;
        }
    }
}