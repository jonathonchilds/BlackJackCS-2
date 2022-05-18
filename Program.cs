using System;
using System.Collections.Generic;


namespace BlackJackCS
{
    class Program
    {

        static void Main(string[] args)
        {

            // var playerHand = new List<string>() { deck[0], deck[1] };
            // var computerHand = new List<string>() { deck[2], deck[3] };

            // Console.WriteLine($"You're holding {playerHand[0]} & {playerHand[1]}. Would you like to \"hit\" or \"stand\"?");

            // var hitOrStand = Console.ReadLine();

            // while (hitOrStand != "stand")
            // {
            //     for (var i = 4; i < playerHand.Count; i++)
            //         playerHand.Add(deck[i]);
            //     Console.WriteLine($"You're holding {playerHand}. Would you like to \"hit\" or \"stand\"?");
            //     hitOrStand = Console.ReadLine();
            // }

        }

    }
    class Card
    {
        public string Suit { get; }
        public string Rank { get; }
        public int Value { get; set; }

        public Card(string suit, string rank)
        {
            Suit = suit;
            Rank = rank;
        }

    }

    class Deck
    {
        public List<Card> Cards { get; }

        public Deck()
        {

            var suits = new List<string>() { "Hearts", "Diamonds", "Spades", "Clubs" };
            var ranks = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
            Cards = new List<Card>();

            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    var card = new Card(suit, rank);
                    Cards.Add(card);
                }
            }
        }
        public void Shuffle()
        {
            var deckLength = Cards.Count;

            for (var rightIndex = deckLength - 1; rightIndex >= 1; rightIndex--)
            {
                var randomNumberGenerator = new Random();
                var leftIndex = randomNumberGenerator.Next(rightIndex);

                var leftCard = Cards[leftIndex];
                var rightCard = Cards[rightIndex];
                Cards[rightIndex] = leftCard;
                Cards[leftIndex] = rightCard;
            }
        }
    }
}

