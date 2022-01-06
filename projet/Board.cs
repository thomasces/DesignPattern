using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet
{
    class Board
    {
        private static Board instance = null;
        public Square[] board = new Square[40];
        private static readonly object padlock = new object();

        public Board()
        {
            CreateBoard();
        }

        public static Board Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Board();
                    }
                    return instance;
                }
            }
        }

        public void CreateBoard()
        {
            board[0] = new Square(); // start
            board[1] = new Square();
            board[2] = new Square();
            board[3] = new Square();
            board[4] = new Square();
            board[5] = new Square();
            board[6] = new Square();
            board[7] = new Square();
            board[8] = new Square();
            board[9] = new Square();
            board[10] = new Square(); //jail
            board[11] = new Square();
            board[12] = new Square();
            board[13] = new Square();
            board[14] = new Square();
            board[15] = new Square();
            board[16] = new Square();
            board[17] = new Square();
            board[18] = new Square();
            board[19] = new Square();
            board[20] = new Square();
            board[21] = new Square();
            board[22] = new Square();
            board[23] = new Square();
            board[24] = new Square();
            board[25] = new Square();
            board[26] = new Square();
            board[27] = new Square();
            board[28] = new Square();
            board[29] = new Square();
            board[30] = new Square(); // go to jail
            board[31] = new Square();
            board[32] = new Square();
            board[33] = new Square();
            board[34] = new Square();
            board[35] = new Square();
            board[36] = new Square();
            board[37] = new Square();
            board[38] = new Square();
            board[39] = new Square();
        }
    }
}
