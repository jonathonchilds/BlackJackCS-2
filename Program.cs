using System;
using System.Collections.Generic;


namespace BlackJackCS
{
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
        public string CardFormat()
        {
            return $"{Rank} of {Suit}";
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
        public Card Deal()
        {
            var newCard = Cards[0];
            Cards.Remove(newCard);
            return newCard;
        }

    }
    class Program
    {

        static string DisplayHand(List<Card> hand)
        {

            var cardNames = "";
            for (var i = 0; i < hand.Count; i++)
            {
                cardNames += hand[i].CardFormat();
                if (i == hand.Count - 2)
                {
                    cardNames += " and ";
                }
                else if (i != hand.Count - 1)
                {
                    cardNames += ", ";
                }
            }
            return cardNames;
        }

        static void Main(string[] args)
        {

            var deck = new Deck();

            deck.Shuffle();

            var playerHand = new List<Card>() { deck.Deal(), deck.Deal() };

            var computerHand = new List<Card>() { deck.Deal(), deck.Deal() };



            Console.WriteLine($"You're holding {DisplayHand(playerHand)}. Would you like to \"hit\" or \"stand\"?");

            var hitOrStand = Console.ReadLine();

            while (hitOrStand != "stand")
            {
                playerHand.Add(deck.Deal());
                Console.WriteLine($"You're holding {DisplayHand(playerHand)}. Would you like to \"hit\" or \"stand\"?");
                hitOrStand = Console.ReadLine();
            }

        }
    }
}

