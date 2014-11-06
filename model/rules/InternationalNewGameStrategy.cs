using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class InternationalNewGameStrategy : INewGameStrategy
    {

        public bool NewGame(Deck a_deck, Dealer a_dealer, Player a_player)
        {
            a_player.showAndDealCard(a_deck);

            a_dealer.showAndDealCard(a_deck);

            a_player.showAndDealCard(a_deck);

            return true;
        }
    }
}
