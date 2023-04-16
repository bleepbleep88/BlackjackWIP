using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Gaming.Blackjack.Models
{

    public enum Suit
    {
        Hearts = 1,
        Spades = 2,
        Clubs = 3,
        Diamonds = 4,
        Jacks = 5,
        Queens = 6,
        Kings = 7,
        Ace = 8
    }

    public class Card
    {
        public int Value { get; set; }
        public Suit Suit { get; set; }

        public Card(int value, Suit suit)
        {
            Value = value;
            Suit = suit;
        }
    }
}
