using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet
{
    class Player
    {
        public string name;
        public bool jail; // true= in jail false= free
        public int pos;
        public bool loser = false;
        public int nb_jail=0;

        public IState pState;



        public IState PState { get => pState; set => pState = value; }

        public string Name { get => name; set => name=value; }

        public int Position { get; set; }

        public bool Jail { get; set; }

        public bool Loser { get; set; }

        public int Nb_jail { get; set; }

        public Player(string name)
        {
            this.name = name;
            this.pos = 0;
            this.pState = new NotInJail();
            this.loser = false;
        }


        /*
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

        public bool DoubleCheck(int[] dices)
        {
            if (dices[0]== dices[1]) { return true; }
            
            else { return false; }
        }

        public void Move(int[] tot)
        {
            if (this.pos+tot[2]<40) { this.pos += tot[2]; }
            else { this.pos= this.pos + tot[2] - 40; }
        }
        */
        public string toString()
        {
            return "Player: " + this.name + "\nPosition: " + this.pos;
        }
    }
}
