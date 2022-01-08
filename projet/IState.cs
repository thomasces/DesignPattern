using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet
{
    interface IState
    {
        int[] RollDices();

        void Move(int[] tot);

        void GoToJail();

        void DoubleCheck(int[] dices);

        void DisplayPosition();
    }
}
