using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Blackjack.app
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Blackjack!");
            Console.WriteLine("House Rules:");
            Console.WriteLine("Dealer stands on 16 or higher");
            Console.WriteLine("Aces are 11 points each (double aces = 22 *Bust).");
            Console.ReadLine();

            var player = new Player();
            var dealer = new Player();
            var d = Deck.BuildDeck();

            player.AddToHand(d.Deal());
            player.AddToHand(d.Deal());

            dealer.AddToHand(d.Deal());
            dealer.AddToHand(d.Deal(), false);

            Console.Clear();
            DisplayHand(player);
            DisplayHand(dealer);

            if (player.HandTotal == 21)
            {
                Console.WriteLine("You won! Blackjack!");
                Console.ReadLine();
                return;
            }

            //Player's Turn Loop
            while (true)
            {
                Console.WriteLine("(H)it or (S)tay");
                var input = Console.ReadLine();

                if (input == "S")
                {
                    break;
                }
                else if (input == "H")
                {
                    player.AddToHand(d.Deal());
                    Console.Clear();
                    DisplayHand(player);
                    DisplayHand(dealer);
                    if (player.HandTotal >= 21)
                    {
                        break;
                    }
                }
                else
                {
                    continue;
                }
            }

            //show dealers cards
            dealer.Hand.ForEach(x=>x.IsVisible = true);
            Console.Clear();
            DisplayHand(player);
            DisplayHand(dealer);

            //Dealers Turn
            while (true)
            {
                if (dealer.HandTotal >= 17)
                {
                    break;
                }

                dealer.AddToHand(d.Deal());
                Console.Clear();
                DisplayHand(player);
                DisplayHand(dealer);
            }

            //Check to see who won
            if (player.HandTotal > 21)
            {
                Console.WriteLine("Dealer Wins!");
                Console.ReadLine();
                return;
            }

            if (dealer.HandTotal > 21)
            {
                Console.WriteLine("Player Wins!");
                Console.ReadLine();
                return;
            }

            if (dealer.HandTotal >= player.HandTotal)
            {
                Console.WriteLine("Dealer Wins!");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Player Wins!");
            Console.ReadLine();

        }

        private static void DisplayHand(Player p)
        {
            Console.WriteLine(p.ToString());
        }
    }
}
