using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Gaming.Blackjack.Models
{
    public class Deck
    {

        public List<Card> Cards { get; set; } = new List<Card>();

        public List<Card> Shuffle(List<Card> cards)
        {
            Random r = new Random();

            for (int n = cards.Count - 1; n > 0; --n)
            {
                int k = r.Next(n + 1);
                Card temp = cards[n];
                cards[n] = cards[k];
                cards[k] = temp;
            }
            return cards;
        }

        public Deck()
        {
            for(int i = 1; i < 10; i++)
            {
                for(int suit = 1; suit <= 4; suit++)
                {
                    Cards.Add(new Card(i, (Suit)suit));
                }
            }
            Cards = Shuffle(Cards);
        }
    }
}
