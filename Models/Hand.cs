using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Gaming.Blackjack.Models
{
    public class Hand
    {
        public List<Card> Cards { get; set; } = new List<Card>();
        public int HandValue { get; set; }
        public bool IsNaturalBlackJack { get; set; }

        public void ResetHand()
        {
            Cards.Clear();
            HandValue = 0;
            IsNaturalBlackJack = false;
        }
    }
}
