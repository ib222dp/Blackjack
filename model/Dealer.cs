using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Dealer : Player
    {
        private Deck m_deck = null;
        private const int g_maxScore = 21;

        private rules.INewGameStrategy m_newGameRule;
        private rules.IHitStrategy m_hitRule;
        private rules.IWinnerStrategy m_winnerRule;
        private List<view.INewCardListener> m_observers;

        public Dealer(rules.RulesFactory a_rulesFactory, view.IView v)
        {
            m_newGameRule = a_rulesFactory.GetNewGameRule();
            m_hitRule = a_rulesFactory.GetHitRule();
            m_winnerRule = a_rulesFactory.GetWinnerRule();
            m_observers = new List<view.INewCardListener>();
            m_observers.Add(v);
        }

        public bool NewGame(Player a_player)
        {
            if (m_deck == null || IsGameOver())
            {
                m_deck = new Deck();
                ClearHand();
                a_player.ClearHand();
                return m_newGameRule.NewGame(this, a_player);
            }
            return false;
        }

        public void PublishNewCardEvent(Card c)
        {
            foreach (view.INewCardListener m_observer in m_observers)
            {
                m_observer.OnNewCardEvent(c);
            }
        }

        public void showAndDealCard(Player a_player)
        {
            Card c = m_deck.GetCard();
            c.Show(true);
            PublishNewCardEvent(c);
            a_player.DealCard(c);
        }

        public void showAndDealCard(bool showCard)
        {
            Card c = m_deck.GetCard();
            c.Show(showCard);
            PublishNewCardEvent(c);
            this.DealCard(c);
        }

        public bool Hit(Player a_player)
        {
            if (m_deck != null && a_player.CalcScore() < g_maxScore && !IsGameOver())
            {
                showAndDealCard(a_player);
                return true;
            }
            return false;
        }

        public bool IsDealerWinner(Player a_player)
        {
            return m_winnerRule.IsDealerWinner(this, a_player, g_maxScore);
        }

        public bool IsGameOver()
        {
            if (m_deck != null && /*CalcScore() >= g_hitLimit*/ m_hitRule.DoHit(this) != true)
            {
                return true;
            }
            return false;
        }

        public bool Stand()
        {
            if (m_deck != null)
            {
                ShowHand();
                IEnumerable<Card> cards = GetHand();

                foreach (Card card in cards)
                {
                    card.Show(true);
                }
                while (m_hitRule.DoHit(this))
                {
                    showAndDealCard(true);
                }
                return true;
            }
            return false;
        }
    }
}