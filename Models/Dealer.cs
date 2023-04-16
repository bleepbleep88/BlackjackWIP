using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Gaming.Blackjack.Models
{
    public class Dealer
    {
        //gives cards, pushes, deals you money, takes ur money, controls the game 
        public Deck Deck { get; set; } = new Deck();
        public Hand Hand { get; set; } = new Hand();

        public Bet DealerBet { get; set; }

        public Dealer()
        {
            DealerBet = new Bet(Hand);
        }

        public Card DispenseCard()
        {
            Card card = Deck.Cards.First();
            Deck.Cards.Remove(card);
/*            if(Deck.Cards.Count < 1)
            {
                Deck = new Deck();
            }*/
            return card;
        }

        public void Reset()
        {
            Hand.ResetHand();
            DealerBet = new Bet(Hand);
        }

    }
}
