using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Gaming.Blackjack.Models
{
    public class Bet
    {
        public int ChipsOnBet { get; set; }
        public bool IsBusted { get; set; }
        public bool Stand { get; set; }
        public Hand Hand { get; set; }

        public Bet(Hand hand)
        {
            Hand = hand;
        }

        public void Hit(Card card)
        {
            Hand.Cards.Add(card);
            if(card.Suit == Suit.Ace && Hand.HandValue > 10)
            {
                Hand.HandValue += 1;
            }
            else if(card.Suit == Suit.Ace)
            {
                Hand.HandValue += 11;
            }
            else
            {
                Hand.HandValue += card.Value;
            }

            if(Hand.Cards.Count == 2 && Hand.HandValue == 21)
            {
                Hand.IsNaturalBlackJack = true;
                Stand = true;
            }
            
            if(Hand.HandValue > 21)
            {
                IsBusted = true;
            }

        }

        public void Double(Card card)
        {
            ChipsOnBet *= 2;
            Hit(card);
        }

    }
}
