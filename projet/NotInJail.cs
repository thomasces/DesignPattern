using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet
{
    public class NotInJail : IState
    {
        private Player p;
        public int nbDouble;

        public NotInJail(Player p)
        {
            this.p = p;
        }

        public int[] RollDices()
        {
            Random random = new Random();
            int dice1 = random.Next(1, 7);
            int dice2 = random.Next(1, 7);
            int total = dice1 + dice2;
            Console.WriteLine("Dice 1:" + dice1);
            Console.WriteLine("Dice 2:" + dice2);
            Console.WriteLine("Total: " + total);
            int[] dices = new int[3];
            dices[0] = dice1;
            dices[1] = dice2;
            dices[2] = total;
            return dices;
        }

        public void Move(int[] tot)
        {
            if (p.pos + tot[2] < 40) { p.pos += tot[2]; }
            else { p.pos = p.pos + tot[2] - 40; }
        }

        public void GoToJail()
        {
            Console.WriteLine("You rolled a double for the third time in a row. You must go to jail.");
            p.inJail = new InJail(p);
            p.pState = p.inJail;
            p.pos = 10;
            Console.WriteLine("You are now in jail.\n");
        }

        public void DisplayPosition()
        {
            Console.WriteLine("The square you are currently on is the following:");
            if (p.pos == 0)
            {
                Console.WriteLine("\nStart square!");
            }
            else if (p.pos == 10)
            {
                Console.WriteLine("\nJail square! But don't worry you are only visiting.");
            }
            else if (p.pos == 30)
            {
                GoToJail();
            }
            else
            {
                Console.WriteLine("\n You are in the case number " + p.pos);
            }
        }

        public void DoubleCheck(int[] dices)
        {
            nbDouble = 0;
            while (dices[0] == dices[1])
            {
                nbDouble += 1;
                if(nbDouble==3)
                {
                    GoToJail();
                    break;
                }
                Console.Clear();
                Console.WriteLine("\nYou made a double, play again !\n");
                
                dices =RollDices();
                Console.ReadKey(true);


                p.pState.Move(dices);
                DisplayPosition();
            }            
        }
    }
}
