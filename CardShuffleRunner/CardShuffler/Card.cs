using CardShuffler.Models;
using System;

namespace CardShuffler
{
    public class Card : IComparable
    {
        public Face Face { get; }
        public Suit Suit { get; }

        public Card(Face face, Suit suit)
        {
            Face = face;
            Suit = suit;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Card))
                return base.Equals(obj);

            Card comparee = (Card)obj;

            if (Face.Equals(comparee.Face) &&
                Suit.Equals(comparee.Suit))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"{Face.ToString()} of {Suit.ToString()}";
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            if (!(obj is Card))
                throw new ArgumentException();

            Card compareObj = (Card)obj;

            return ((int)Suit + (int)Face) - ((int)compareObj.Suit + (int)compareObj.Face);
        }
    }

}
