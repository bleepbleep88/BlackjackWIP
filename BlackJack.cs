using Assets.Gaming.Blackjack.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BlackJack : MonoBehaviour
{
    // Start is called before the first frame update
    Dealer dealer;
    public Round round;
    public List<Player> players = new List<Player>();
    void Start()
    {
        dealer = new Dealer();
        players.Add(new Player());
        round = new Round(dealer, players);
        round.StartGame();
        Hit(players.First());
        Stand(players.First());
        
        NewRound();
        Console.Write('d');
        // all players have something now
    }

    void StartGame()
    {
        dealer = new Dealer();
        players.Add(new Player());
        round = new Round(dealer, players);
        round.StartGame();
    }

    void NewRound()
    {
        round = new Round(dealer, players);
        dealer.Reset();
        players.ForEach(p => p.ResetBet());
        round.StartGame();
    }

    void EnterTable(Player player)
    {
        players.Add(player);
    }

    void LeaveTable(Player player)
    {
        round.Players.Remove(player);
    }

    void Hit(Player player)
    {
        if(!GameOver())
        {
            if (!player.Bet.IsBusted)
            {
                player.Bet.Hit(dealer.DispenseCard());
            }
            else
            {
                // tell player he is a bad kitten
            }
        }
    }

    void Stand(Player player)
    {
        player.Bet.Stand = true;
        while(dealer.Hand.HandValue < round.Players.Where(p => !p.Bet.IsBusted && p.Bet.Stand).Max(p => p.Hand.HandValue))
        {
            dealer.DealerBet.Hit(dealer.DispenseCard());
        }

        if(round.DealerCheck())
        {
            NewRound();
        }

    }

    void Double(Player player)
    {
        if (!GameOver())
        {
            if (!player.Bet.IsBusted && player.TotalChips >= player.Bet.ChipsOnBet * 2)
            {
                player.Bet.Double(dealer.DispenseCard());
            }
            else
            {
                // tell player he is a bad kitten
            }
        }
    }

    bool GameOver()
    {
        if (round.DealerCheck())
        {
            return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
