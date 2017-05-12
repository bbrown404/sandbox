using CardShuffler.Models;
using System;
using System.Collections.Generic;

namespace CardShuffler
{
    public class Deck
    {
        private Random rng;
        public List<Card> Cards { get; private set; }

        public Deck()
        {
            rng = new Random();
            NewDeck();
        }

        /// <summary>
        /// Creates a new Deck of cards in native order,
        /// with a seed for the random number generator 
        /// to enhance unit testing.
        /// </summary>
        /// <param name="seed">A seed for the random number generator for unit testing.</param>
        public Deck(int seed)
        {
            rng = new Random(seed);
            NewDeck();
        }

        /// <summary>
        /// Creates a new Deck and fills it with cards in their native order.
        /// </summary>
        private void NewDeck()
        {
            Cards = new List<Card>();

            var cardFaces = Enum.GetValues(typeof(Face));
            var suits = Enum.GetValues(typeof(Suit));
            foreach (Suit suit in suits)
            {
                foreach (Face face in cardFaces)
                {
                    Cards.Add(new Card(face, suit));
                }
            }
        }

        public void ShuffleDeck()
        {
            List<Card> shuffled = new List<Card>();
            for (int i = 52; i > 0; i--)
            {
                // Pick between the # of cards left and 1.
                // Subtract 1 to become zero based.
                int pick = rng.Next(1, i) - 1;
                shuffled.Add(Cards[pick]);
                Cards.RemoveAt(pick);
            }

            Cards = shuffled;
        }

        /// <summary>
        /// Orders the deck by having a new one made.
        /// </summary>
        public void NativeOrderDeck()
        {
            NewDeck();
        }

        /// <summary>
        /// Orders the deck in place, also allows for ordering descending.
        /// </summary>
        /// <param name="ascending">True for ascending order, false for decending order</param>
        public void OrderDeckInPlace(bool ascending)
        {
            if (ascending)
            {
                Cards.Sort();
            }
            else
            {
                Cards.Sort((x, y) => y.CompareTo(x));
            }
        }
    }
}
