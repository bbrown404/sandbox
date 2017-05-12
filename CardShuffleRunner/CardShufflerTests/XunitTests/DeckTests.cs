using CardShuffler;
using CardShuffler.Models;
using System.Collections.Generic;
using Xunit;

namespace CardShufflerTests
{
    public class DeckTests
    {
        [Fact]
        public void NewDeck_CardOrderMatchesModel()
        {
            Deck target = new Deck();

            AssertAscendingOrder(target, true);
        }

        [Fact]
        public void NativeOrderDeck_ResultingCardOrderMatchesModel()
        {
            Deck target = GetShuffledDeck();
            target.NativeOrderDeck();

            AssertAscendingOrder(target, true);
        }

        private static void AssertAscendingOrder(Deck target, bool ascending)
        {
            Card lastCard = null;

            foreach (Card card in target.Cards)
            {
                if (lastCard == null)
                {
                    lastCard = card;
                    continue;
                }
                var difference = card.CompareTo(lastCard);
                if (ascending)
                    Assert.True(difference > 0);
                else
                    Assert.True(difference < 0);

                lastCard = card;
            }
        }

        [Fact]
        public void ShuffleDeck_DeckOrderIsPsudoRandom()
        {
            // Fix the deck's rng so the order is predictable.
            Deck target = new Deck(1);
            target.ShuffleDeck();
            List<OrderedCard> expectedCards = new List<OrderedCard>();
            expectedCards.Add(new OrderedCard { Card = new Card(Face.King, Suit.Spades), DeckOrder = 0 });
            expectedCards.Add(new OrderedCard { Card = new Card(Face.Six, Suit.Spades), DeckOrder = 1 });
            expectedCards.Add(new OrderedCard { Card = new Card(Face.Queen, Suit.Hearts), DeckOrder = 2 });
            expectedCards.Add(new OrderedCard { Card = new Card(Face.Two, Suit.Diamonds), DeckOrder = 3 });
            expectedCards.Add(new OrderedCard { Card = new Card(Face.Jack, Suit.Spades), DeckOrder = 49 });
            expectedCards.Add(new OrderedCard { Card = new Card(Face.Six, Suit.Diamonds), DeckOrder = 50 });
            expectedCards.Add(new OrderedCard { Card = new Card(Face.King, Suit.Diamonds), DeckOrder = 51 });

            foreach (OrderedCard expectedCard in expectedCards)
            {
                Assert.True(expectedCard.Card.Equals(target.Cards[expectedCard.DeckOrder]),
                    $"Expected {expectedCard.Card.ToString()} at spot {expectedCard.DeckOrder}, found {target.Cards[expectedCard.DeckOrder].ToString()}");
            }
        }

        [Fact]
        public void OrderDeckInPlace_OrdersDeckAscendingOnTrueParam()
        {
            Deck deck  = GetShuffledDeck();
            deck.OrderDeckInPlace(true);

            AssertAscendingOrder(deck, true);
        }

        [Fact]
        public void OrderDeckInPlace_OrdersDeckDescendingOnFalseParam()
        {
            Deck deck = GetShuffledDeck();
            deck.OrderDeckInPlace(false);

            AssertAscendingOrder(deck, false);
        }

        private static Deck GetShuffledDeck()
        {
            Deck deck = new Deck(1);
            deck.ShuffleDeck();
            Assert.True(deck.Cards[0].ToString() != "Ace of Spades",
                "Expected a different card that Ace of Spades to be first after a seeded shuffle");
            return deck;
        }

        private class OrderedCard
        {
            public Card Card { get; set;}

            /// <summary>
            /// Zero based index of this card in the deck
            /// </summary>
            public int DeckOrder { get; set; }
        }

    }
}
