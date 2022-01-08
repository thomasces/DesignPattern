using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet
{
    class Game
    {
        public List<Player> players = new List<Player>(); // who is playing
        public Board board_game = new Board();
        public Player winner;
        public Player current;
        public int compt;

        public Game() { }

        public bool IsWinner()
        {
            int j = 0;
            foreach (Player p in players)
            {
                if (p.loser == false) { winner = p; j++; }
            }
            if (j == 1) { return true; }
            else { return false; }
        }

        public void Create()
        {
            Console.WriteLine("Welcome!");
            int nbpl = 0;
            while (nbpl < 2 || nbpl > 6)
            {
                Console.WriteLine("How many players (2-6)?");
                nbpl = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < nbpl; i++)
            {
                Console.WriteLine("Player " + (i + 1) + ":");
                Console.Write("Username: ");
                string name = Console.ReadLine();
                Player temppl = new Player(name);
                players.Add(temppl);
                Console.WriteLine("\nThe player was successfully added!\n");
            }
            Console.WriteLine("\nPlayers:");
            for (int i = 0; i < nbpl; i++)
            {
                Console.WriteLine("\n" + players[i].toString());
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nPress any key to start the game !\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey(true);
        }

        public void Start()
        {
            compt = 0;
            Console.Clear();
            Console.WriteLine("The game is starting!");
            while (!IsWinner())
            {
                Console.Clear();
                /*
                while (players[compt].loser)
                {
                    if (compt == players.Count - 1)
                    {
                        compt = 0;
                    }
                    else
                    {
                        compt++;
                    }
                }*/
                current = players[compt];
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nPlayer " + current.Name + ":");
                Console.ForegroundColor = ConsoleColor.White;


                Console.WriteLine("\nPress any key to roll the dices !\n");
                Console.ReadKey(true);
                int[] dices=current.pState.RollDices();

                current.pState.Move(dices);
                current.pState.DisplayPosition();
                Console.ReadKey(true);


                current.pState.DoubleCheck(dices);
                DisplayMenu(current,true);


                /*
                if (current.PState is InJail)
                {
                    Console.WriteLine("\nPress any key to roll the dices !\n");
                    Console.ReadKey(true);
                    int[] dices2 = current.PState.RollDices();
                    Console.ForegroundColor = ConsoleColor.Green;


                    if(current.DoubleCheck(dices2))
                    {
                        current.Move(dices2);
                        current.jail = false;
                        current.nb_jail = 0;
                        Console.WriteLine("\nCurrent position :" + current.pos + "\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        //Console.ReadKey(true);
                        //DisplayMenu(current, compt, true);
                    }
                    else if (current.nb_jail != 3)
                    { 
                        current.nb_jail = current.nb_jail + 1;
                        Console.WriteLine("You stay in jail!");
                        Console.ReadKey(true);
                        DisplayMenu(current, compt, true);
                    }      
                    else
                    {
                        current.Move(dices2);
                        current.jail = false;
                        current.nb_jail = 0;
                        Console.WriteLine("\nCurrent position :" + current.pos + "\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else
                {
                    Console.WriteLine("\nPress any key to roll the dices !\n");
                    Console.ReadKey(true);
                    int[] dices = current.Dice();
                    int nbdouble = 0;
                    Console.ForegroundColor = ConsoleColor.Green;
                    current.Move(dices);
                    Console.WriteLine("\nCurrent position :" + current.pos + "\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey(true);
                    DisplayMenu(current, compt, true);

                    while (current.DoubleCheck(dices))
                    {
                        nbdouble++;
                        if (nbdouble == 3)
                        {
                            Console.WriteLine("You rolled a double for the third time in a row. You must go to jail.");
                            current.jail = true;
                            current.pos = 10;
                            Console.WriteLine("You are now in jail.\n");
                            Console.ReadKey(true);
                            break;
                        }
                        Console.WriteLine("\nWow, you got a double, you can roll the dices again !");
                        Console.WriteLine("\nPress any key to roll the dices !\n");
                        Console.ReadKey(true);
                        dices = current.Dice();
                        current.Move(dices);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nCurrent position :" + current.pos + "\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadKey(true);
                        DisplayMenu(current, compt, true);
                    }
                    if (compt == players.Count - 1)
                    {
                        compt = 0;
                    }
                    else
                    {
                        compt++;
                    }
                }
                */
            }            
            Console.ReadKey(true);
        }

        public void DisplayMenu(Player player, bool pos)
        {
            Console.Clear();
            if (pos)
            {
                player.pState.DisplayPosition();
            }
            int resp = 0;
            Console.WriteLine("\nPlease Make a Selection :\n");
            Console.WriteLine("0 : Game Status");
            Console.WriteLine("1 : Finish Turn");
            Console.WriteLine("2 : Your DashBoard");
            Console.WriteLine("3 : Quit Game");
            Console.Write("(1-3)>");
            try
            {
                resp = int.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                this.DisplayMenu(player, true);
            }

            switch (resp)
            {
                case 0:
                    Console.WriteLine("Game Status :");
                    for (int i = 0; i < players.Count; i++)
                    {
                        Console.WriteLine("\n" + players[i].toString());
                    }
                    Console.ReadKey();
                    Console.Clear();
                    DisplayMenu(player, pos);
                    break;
                case 1:
                    if (compt == players.Count - 1)
                    {
                        compt = 0;
                    }
                    else
                    {
                        compt++;
                    }
                    current = players[compt];
                    break;
                case 2:
                    Dashboard(player);
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
            }
        }

        /*
        public void DisplayPosition(Player player, int compt)
        {
            Console.WriteLine("The square you are currently on is the following:");
            EmptySquare(player, compt);
        }
        
        public void EmptySquare(Player player, int compt)
        {
            if (player.pos == 0)
            {
                Console.WriteLine("\nStart square!");
            }
            else if (player.pos == 10)
            {
                Console.WriteLine("\nJail square! But don't worry you are only visiting.");
            }
            else if (player.pos == 30)
            {
                Console.WriteLine("\nGo to jail!");
                player.pState = new InJail(player);
                player.pos = 10;
                Console.WriteLine("You are now in jail.");
                Console.WriteLine("\nPress any key to go back to the menu.");
                Console.ReadKey(true);
                DisplayMenu(player, compt, false);
            }
            else
            {
                Console.WriteLine("\n You are in the case number " + player.pos);
            }
        }
        */
        
        public void Dashboard(Player player)
        {
            Console.Clear();
            Console.WriteLine("Your position is: " + player.pos);

            Console.WriteLine("\n\nPress any key to go back to the menu.");
            Console.ReadKey(true);
            DisplayMenu(player, false);
        }
    }
}
