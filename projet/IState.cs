using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet
{
    public interface IState
    {

        void Move(int[] tot);

        void GoToJail();

        int[] RollDices();

        void DoubleCheck(int[] dices);

        void DisplayPosition();
    }
}
