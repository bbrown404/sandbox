using CardShuffler;
using CardShuffler.Models;
using System.Collections.Generic;
using Xunit;

namespace CardShufflerTests
{
    public class CardTests
    {
        public static IEnumerable<object[]> CardComparisonData
        {
            get
            {
                return new[]
                {
                    new object[]
                    {
                        new Card( Face.Ace, Suit.Clubs),
                        new Card(Face.Ace, Suit.Clubs),
                        0
                    },
                    new object[]
                    {
                        new Card( Face.King, Suit.Diamonds),
                        new Card(Face.Three, Suit.Clubs),
                        110
                    },
                    new object[]
                    {
                        new Card( Face.Queen, Suit.Hearts),
                        new Card(Face.Four, Suit.Diamonds),
                        -192
                    },
                };
            }
        }

        [MemberData(nameof(CardComparisonData))]
        [Theory]
        public void CompareCard_ReturnsExpectedValues(Card a, Card b, int expected)
        {
            Assert.Equal(expected, a.CompareTo(b));
        }

        public static IEnumerable<object[]> CardEqualsData
        {
            get
            {
                return new[]
                {
                    new object[]
                    {
                        new Card(Face.Ace, Suit.Spades),
                        new Card(Face.Ace, Suit.Spades),
                        true
                    },
                    new object[]
                    {
                        new Card(Face.Ace, Suit.Spades),
                        new Card(Face.Two, Suit.Spades),
                        false
                    },
                    new object[]
                    {
                        new Card(Face.Ace, Suit.Spades),
                        "totally a card",
                        false
                    }
                };
            }
        }

        [MemberData(nameof(CardEqualsData))]
        [Theory]
        public void Equals_RetunsExpectedResult(Card a, object b, bool expected)
        {
            Assert.Equal(expected, a.Equals(b));
        }

        [Fact]
        public void ToString_ReturnsCorrectDescription()
        {
            var expected = "Ace of Spades";
            Card actual = new Card(Face.Ace, Suit.Spades);
            Assert.Equal(expected, actual.ToString());
        }
    }
}
