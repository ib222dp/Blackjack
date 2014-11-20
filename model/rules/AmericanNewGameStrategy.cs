using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class AmericanNewGameStrategy : INewGameStrategy
    {
        public bool NewGame(Dealer a_dealer, Player a_player)
        {
            a_dealer.showAndDealCard(a_player);

            a_dealer.showAndDealCard(true);

            a_dealer.showAndDealCard(a_player);

            a_dealer.showAndDealCard(false);

            return true;
        }
    }
}
