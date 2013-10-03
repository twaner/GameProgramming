using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleCards;

namespace ProgrammingAssignment3
{
    class Program
    {
        /// <summary>
        /// Sets a hand's cards status to show all and prints them
        /// </summary>
        /// <param name="hand">list of blackjack hands</param>
        public static void showAndPrint(List<BlackjackHand> hand)
        {
            foreach (var i in hand)
	        {
                i.ShowAllCards();
                i.Print();
	        }
        }

        /// <summary>
        /// shows scores for all black jack hands
        /// </summary>
        /// <param name="hand">list of blackjack hands</param>
        public static void showScores(List<BlackjackHand> hand)
        {
            foreach (var i in hand)
            {
                Console.Write(String.Format("{0} had a score of {1}.\n", i, i.Score));
            }
        }

        /// <summary>
        /// deals hand of two cards to each player in game
        /// </summary>
        /// <param name="hands">list of player hands</param>
        /// <param name="deck"> deck of cards </param>
        public static void dealHands(List<BlackjackHand> hands, Deck deck)
        {   
             for (int i = 0; i < 2; i++)
            {
                foreach (var h in hands)
                {
                    h.AddCard(deck.TakeTopCard());
                }
            }
        }

        static void Main(string[] args)
        {
            // Create players, deck, and list of hands
            BlackjackHand playerHand = new BlackjackHand("Player");
            BlackjackHand deadlerHand = new BlackjackHand("Dealer");
            Deck deck = new Deck();
            List<BlackjackHand> hands = new List<BlackjackHand>() { playerHand, deadlerHand }; 
            
            //print welcome message
            Console.Write("Welcome. This program will play a single hand of black jack.\n");

            //shuffle
            // deal cards
            deck.Shuffle();
            dealHands(hands, deck);
            
            //show player cards and 1 dealer
            playerHand.ShowAllCards();
            deadlerHand.ShowFirstCard();

            // print hands
            foreach (var i in hands)
            {
                i.Print();
            }

            // ask player to hit or not
            playerHand.HitOrNot(deck);

            //show and print hands and player scores
            showAndPrint(hands);
            showScores(hands);

            // Graceful exit
            Console.WriteLine("\nPress any key to exit.\n");
            Console.ReadLine();
            Environment.Exit(0);

        }
    }
}
