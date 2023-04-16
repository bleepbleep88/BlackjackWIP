using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Gaming.Blackjack.Models
{
    public class Player
    {
        public int TotalChips { get; set; }
        public int CurrentChipBet { get; set; }
        public Hand Hand { get; set; } = new Hand();
        public Bet Bet { get; set; }

        public Player()
        {
            Bet = new Bet(Hand) { ChipsOnBet = CurrentChipBet };
        }

        public void ResetBet()
        {
            Hand.ResetHand();
            Bet = new Bet(Hand) { ChipsOnBet = CurrentChipBet };
        }
    }
}
