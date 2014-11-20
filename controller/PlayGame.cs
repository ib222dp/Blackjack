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
            view.PlayerInput playerInput = view.PlayerInput.Indefinite;

            a_view.DisplayWelcomeMessage();

            a_view.DisplayDealerHand(a_game.GetDealerHand(), a_game.GetDealerScore());
            a_view.DisplayPlayerHand(a_game.GetPlayerHand(), a_game.GetPlayerScore());

            if (a_game.IsGameOver())
            {
                a_view.DisplayGameOver(a_game.IsDealerWinner());
            }

            playerInput = a_view.GetInput();

            if (playerInput == view.PlayerInput.Play)
            {
                a_game.NewGame();
            }
            else if (playerInput == view.PlayerInput.Hit)
            {
                a_game.Hit();
            }
            else if (playerInput == view.PlayerInput.Stand)
            {
                a_game.Stand();
            }

            return playerInput != view.PlayerInput.Quit;
        }
    }
}
