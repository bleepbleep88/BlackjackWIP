using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Gaming.Blackjack.Models
{
    public class Round
    {
        public List<Player> Players { get; set; }
        public Dealer Dealer { get; set; }

        //return true if round over

        public Round(Dealer dealer, List<Player> players)
        {
            Players = players;
            Dealer = dealer;
        }

        public void StartGame()
        {
            Dealer.DealerBet.Hit(Dealer.DispenseCard());
            foreach(Player player in Players)
            {
                player.Bet.Hit(Dealer.DispenseCard());
            }
        }
        public bool IsRoundOver()
        {
            if(Dealer.DealerBet.IsBusted)
            {
                return true;
            }

            return Players.All(p => p.Bet.IsBusted || p.Bet.Stand);
        }

        public void Payout()
        {
            List<Player> playersToPayout = new List<Player>();
            foreach (Player player in Players)
            {
                if (!player.Bet.IsBusted && player.Hand.HandValue >= Dealer.Hand.HandValue)
                {
                    if (Dealer.Hand.IsNaturalBlackJack && !player.Hand.IsNaturalBlackJack)
                        continue;
                    playersToPayout.Add(player);
                }
            }

            foreach(Player player in playersToPayout)
            {
                if (player.Hand.HandValue == Dealer.Hand.HandValue || Dealer.Hand.IsNaturalBlackJack && player.Hand.IsNaturalBlackJack)
                {
                    player.TotalChips += player.Bet.ChipsOnBet;
                }
                else if (!Dealer.Hand.IsNaturalBlackJack && player.Hand.IsNaturalBlackJack)
                {
                    player.TotalChips += (int) (player.Bet.ChipsOnBet * 1.5);
                }
                else if (player.Hand.HandValue != Dealer.Hand.HandValue)
                {
                    player.TotalChips += player.Bet.ChipsOnBet * 2;
                }
            }
        }

        public bool DealerCheck()
        {
            if (IsRoundOver())
            {
                Payout();
                return true;
            }
            // reset game, change players if need be
            return false;
        }
    }
}
