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
        public int pos;
        public IState pState;

        public IState PState { get => pState; set => pState = value; }

        public string Name { get => name; set => name=value; }

        public int Position { get; set; }

        public Player(string name)
        {
            this.name = name;
            this.pos = 0;
            this.pState = new NotInJail(this);
        }
        public string toString()
        {
            return "Player: " + this.name + "\nPosition: " + this.pos;
        }
    }
}
