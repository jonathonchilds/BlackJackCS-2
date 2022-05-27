using System;
using System.Collections.Generic;


namespace BlackJackCS
{
    class Card
    {
        public string Suit { get; }
        public string Rank { get; }
        public int Value { get; }

        public Card(string suit, string rank)
        {
            Suit = suit;
            Rank = rank;
            Value = CalculateValue();
        }

        public string CardFormat()
        {
            return $"{Rank} of {Suit}";
        }

        private int CalculateValue()
        {
            switch (Rank)
            {
                case "Jack":
                case "Queen":
                case "King":
                    return 10;

                case "Ace":
                    return 11;

                default:
                    return int.Parse(Rank);
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

            static int ScoreHand(List<Card> hand)
            {
                int cardTotal = 0;
                for (var i = 0; i < hand.Count; i++)
                {
                    cardTotal += hand[i].Value;

                }
                return cardTotal;
            }


            static void Main(string[] args)
            {
                var deck = new Deck();
                deck.Shuffle();

                var playerHand = new List<Card>() { deck.Deal(), deck.Deal() };

                var computerHand = new List<Card>() { deck.Deal(), deck.Deal() };

                var hitOrStand = "";

                // == 21 does not mean busted
                // 

                if (ScoreHand(playerHand) < 21)
                {
                    do
                    {
                        Console.WriteLine($"You're holding {DisplayHand(playerHand)}, totaling {ScoreHand(playerHand)}. Would you like to \"hit\" or \"stand\"?");
                        hitOrStand = Console.ReadLine();
                        if (hitOrStand == "hit")
                        {
                            playerHand.Add(deck.Deal());
                        }
                    }
                    while (hitOrStand == "hit" && ScoreHand(playerHand) < 21);
                }
                if (ScoreHand(playerHand) == 21)
                {
                    Console.WriteLine($"You got Blackjack!");
                }
                else if (ScoreHand(playerHand) > 21)
                {
                    Console.WriteLine($"You're holding {DisplayHand(playerHand)}, totaling {ScoreHand(playerHand)}. You busted! Computer wins.");
                    Environment.Exit(0);
                }


                Console.WriteLine($"You're holding {DisplayHand(playerHand)}, totaling {ScoreHand(playerHand)}");


                while (ScoreHand(computerHand) < 17 && ScoreHand(computerHand) < 22)
                {
                    computerHand.Add(deck.Deal());
                }

                if (ScoreHand(computerHand) == 21)
                {
                    Console.WriteLine($"Computer gets Blackjack!");
                }
                else if (ScoreHand(computerHand) > 21)
                {
                    Console.WriteLine($"Computer is holding {ScoreHand(computerHand)}. Computer busted! You win!");
                    Environment.Exit(0);
                }

                var computerHandTotal = ScoreHand(computerHand);
                var playerHandTotal = ScoreHand(playerHand);

                Console.WriteLine($"The house is holding {DisplayHand(computerHand)}, totaling {ScoreHand(computerHand)}");

                if (computerHandTotal < playerHandTotal)
                {
                    Console.WriteLine($"You win!");
                }
                else if (computerHandTotal == playerHandTotal)
                {
                    Console.WriteLine($"It's a tie. Computer wins!");

                }
                else
                {
                    Console.WriteLine($"Computer wins!");
                }
            }
        }
    }
}



