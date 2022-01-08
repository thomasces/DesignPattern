using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet
{
    public class Player
    {
        public string name;
        public int pos;
        public IState pState;
        public NotInJail notinjail;
        public InJail inJail;

        public IState PState { get => pState; set => pState = value; }

        public string Name { get => name; set => name=value; }

        public int Position { get; set; }

        public Player(string name)
        {
            this.name = name;
            this.pos = 0;
            this.notinjail = new NotInJail(this);
            this.inJail = new InJail(this);
            this.pState = notinjail;
        }
        public string toString()
        {
            return "Player: " + this.name + "\nPosition: " + this.pos;
        }
    }
}
