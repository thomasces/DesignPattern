using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet
{
    class InJail : IState
    {
        private Player p;
        private int timer = 1;

        public InJail(Player p)
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
            if (timer==3)
            {
                p.pState = new NotInJail(p);
            }
            timer++;
            return dices;
        }

        public void Move(int[] tot)
        {
            Console.WriteLine("You can't move! You are in jail!");
        }

        public void GoToJail()
        {
            Console.WriteLine("You are already in jail!");
        }

        public void DoubleCheck(int[] dices)
        {
            if (dices[0] == dices[1]) 
            {
                Console.WriteLine("But you made a double, Congratulation !");
                Console.WriteLine("You are now free!");
                p.PState=new NotInJail(p);
                p.pState.Move(dices);
            }
        }

        public void DisplayPosition()
        {
            Console.WriteLine("You are in Jail!");
        }
    }
}
