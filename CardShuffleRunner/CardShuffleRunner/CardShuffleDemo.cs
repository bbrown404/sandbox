using CardShuffler;
using System;
using System.Diagnostics;

namespace CardShuffleRunner
{
    class CardShuffleDemo
    {
        const int TargetSize = 50000;
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Demo.");
            PressAny();

            Console.WriteLine("Printing Deck in order:");
            Deck deck = new Deck();
            PrintDeck(deck);
            PressAny();

            Console.WriteLine("Printing shuffled deck.");
            deck.ShuffleDeck();
            PrintDeck(deck);
            PressAny();

            Console.WriteLine("Printing ordered deck.");
            deck.NativeOrderDeck();
            PrintDeck(deck);
            PressAny();

            Console.WriteLine("Now to compare ordering in place vs creating a new deck to order the cards.");
            PressAny();
            ComparisonTest();

            Console.WriteLine("Demo finished");
        }

        private static void PrintDeck(Deck deck)
        {
            foreach (Card card in deck.Cards)
            {
                Console.WriteLine(card.ToString());
            }
            Console.WriteLine();

        }

        private static void PressAny()
        {
            Console.WriteLine("Press Enter to continue");
            Console.WriteLine();
            Console.ReadKey();
        }

        private static void ComparisonTest()
        {
            Console.WriteLine($"Shuffling three sets of {TargetSize} decks, then timing how long it takes to order them in various ways.");
            Deck[] makeNew = new Deck[TargetSize];
            Deck[] inPlace = new Deck[TargetSize];
            Deck[] reverse = new Deck[TargetSize];
            for (int i = 0; i < TargetSize; i++)
            {
                makeNew[i] = new Deck();
                makeNew[i].ShuffleDeck();
                inPlace[i] = new Deck();
                inPlace[i].ShuffleDeck();
                reverse[i] = new Deck();
                reverse[i].ShuffleDeck();
            }

            Stopwatch time1 = new Stopwatch();
            time1.Start();
            for (int i = 0; i < TargetSize; i++)
            {
                makeNew[i].NativeOrderDeck();
            }
            time1.Stop();
            Console.WriteLine($"Ordered {TargetSize} decks by throwing the decks away and creating new ones, in {time1.ElapsedMilliseconds}ms.");

            time1.Reset();
            time1.Start();
            for (int i = 0; i < TargetSize; i++)
            {
                inPlace[i].OrderDeckInPlace(true);
            }
            time1.Stop();
            Console.WriteLine($"Ordered {TargetSize} decks by ordering the cards in the deck, in {time1.ElapsedMilliseconds}ms.");

            time1.Reset();
            time1.Start();
            for (int i = 0; i < TargetSize; i++)
            {
                reverse[i].OrderDeckInPlace(false);
            }
            time1.Stop();
            Console.WriteLine($"Reverse ordered {TargetSize} decks by ordering the cards in the deck, in {time1.ElapsedMilliseconds}ms.");
        }
    }
}
