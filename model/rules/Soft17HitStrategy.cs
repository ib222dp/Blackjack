using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class Soft17HitStrategy : IHitStrategy
    {
        private const int g_hitLimit = 17;

        public bool DoHit(model.Player a_dealer)
        {
            int score = a_dealer.CalcScore();
            if (score == g_hitLimit)
            {
                int[] cardScores = new int[(int)model.Card.Value.Count] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11 };
                IEnumerable<Card> cards = a_dealer.GetHand();
                foreach (Card card in cards)
                {
                    if(cardScores[(int)card.GetValue()] == 11)
                    {
                        score = (score - 10);
                    }
                }
            }
            return score < g_hitLimit;
        }
    }
}
