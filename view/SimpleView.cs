using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.view
{
    class SimpleView : IView
    {
        private static string play = "p";
        private static string hit = "h";
        private static string stand = "s";
        private static string quit = "q";

        public void DisplayWelcomeMessage()
        {
            System.Console.Clear();
            System.Console.WriteLine("Hello Black Jack World");
            System.Console.WriteLine("Type {0} to Play, {1} to Hit, {2} to Stand or {3} to Quit\n", play, hit, stand, quit);
        }

        public PlayerInput GetInput()
        {
            string letter = System.Console.ReadLine();
            PlayerInput playerInput = PlayerInput.Indefinite;

            if (letter == play)
            {
                playerInput = PlayerInput.Play;
            }
            else if (letter == hit)
            {
                playerInput = PlayerInput.Hit;
            }
            else if (letter == stand)
            {
                playerInput = PlayerInput.Stand;
            }
            else if (letter == quit)
            {
                playerInput = PlayerInput.Quit;
            }

            return playerInput;
        }

        public void DisplayCard(model.Card a_card)
        {
            System.Console.WriteLine("{0} of {1}", a_card.GetValue(), a_card.GetColor());
        }

        public void DisplayPlayerHand(IEnumerable<model.Card> a_hand, int a_score)
        {
            DisplayHand("Player", a_hand, a_score);
        }

        public void DisplayDealerHand(IEnumerable<model.Card> a_hand, int a_score)
        {
            DisplayHand("Dealer", a_hand, a_score);
        }

        private void DisplayHand(String a_name, IEnumerable<model.Card> a_hand, int a_score)
        {
            System.Console.WriteLine("{0} Has: ", a_name);
            foreach (model.Card c in a_hand)
            {
                DisplayCard(c);
            }
            System.Console.WriteLine("Score: {0}", a_score);
            System.Console.WriteLine("");
        }

        public void DisplayGameOver(bool a_dealerIsWinner)
        {
            System.Console.Write("GameOver: ");
            if (a_dealerIsWinner)
            {
                System.Console.WriteLine("Dealer Won!");
            }
            else
            {
                System.Console.WriteLine("You Won!");
            }
        }

        public void OnNewCardEvent(model.Card c)
        {
            System.Threading.Thread.Sleep(2000);
            DisplayCard(c);
        }
    }
}
