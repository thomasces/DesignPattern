using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet
{
    class NotInJail : IState
    {
        private Player p;

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
            if (p.Position + tot[2] < 40) { p.Position += tot[2]; }
            else { p.Position = p.Position + tot[2] - 40; }
        }

        public void GoToJail()
        {
            
        }
    }
}
