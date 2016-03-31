namespace Blackjack.app
{
    public enum Suit
    {
        Hearts = 0,
        Clubs = 1,
        Diamonds = 2,
        Spades = 3
    }

    public enum Rank

    {
        Deuce = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 1
    }

    public class Card
    {

        public Card(Suit s, Rank r)
        {
            this.Suit = s;
            this.Rank = r;
        }

        public bool IsVisible { get; set; } = true;
        public Suit Suit { get; set; }
        public Rank Rank { get; set; }

        public int Value
        {
            get
            {
                switch (Rank)
                {
                    case Rank.Jack:
                    case Rank.Queen:
                    case Rank.King:
                        return 10;
                    case Rank.Ace:
                        return 11;
                    default:
                        return (int) Rank;
                }
            }
        }

        public override string ToString()
        {
            if (this.IsVisible)
            return $"{this.Rank} {this.Suit}";
            else
            {
                return "XXXXX   XXXXXX ";
            }
        }
    }
}