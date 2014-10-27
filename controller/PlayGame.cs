using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.controller
{
    class PlayGame
    {
        public bool Play(model.Game a_game, view.IView a_view)
        {
            a_view.DisplayWelcomeMessage();

            a_view.DisplayDealerHand(a_game.GetDealerHand(), a_game.GetDealerScore());
            a_view.DisplayPlayerHand(a_game.GetPlayerHand(), a_game.GetPlayerScore());

            if (a_game.IsGameOver())
            {
                a_view.DisplayGameOver(a_game.IsDealerWinner());
            }
            int input = 0;
            try
            {
                input = a_view.GetInput();
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }

            if (input == 1)
            {
                a_game.NewGame();
            }
            else if (input == 2)
            {
                a_game.Hit();
            }
            else if (input == 3)
            {
                a_game.Stand();
            }

            return input != 4;
        }
    }
}
