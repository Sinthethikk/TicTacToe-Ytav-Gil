using System;

namespace TicTacToe_Ytav_Gil
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your usernames and select your player (X/O)");
            Console.Write($"Player 1 (X):");
            string p1x = Console.ReadLine();
            Console.Write($"\nPlayer 2 (O):");
            string p2o = Console.ReadLine();

            int GST = 0;
            char[] spotsArr = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            int CPlayer = -1;
            

            do 
            {
                Console.Clear();

                CPlayer = NextP(CPlayer);
                Welcome(CPlayer,ref p1x,ref p2o);
                PrintBoard(spotsArr);
                Functionality(spotsArr, CPlayer);

                GST = WCheck(spotsArr);
            }
            while (GST.Equals(0));

            if (GST.Equals(1))
            {
                Console.Clear();
                Welcome(CPlayer, ref p1x, ref p2o);
                PrintBoard(spotsArr);
                Console.WriteLine("\n");
                Console.WriteLine($"Player {CPlayer} Wins!");
            }

            if (GST.Equals(2))
            {
                Console.Clear();
                Welcome(CPlayer, ref p1x, ref p2o);
                PrintBoard(spotsArr);
                Console.WriteLine("\n");
                Console.WriteLine($"Draw!");

            }

            

        }

        

        static void PrintBoard(char[] spotsArr)
        {
            

            
            Console.WriteLine("     |     |     ");
            Console.WriteLine($"  {spotsArr[0]}  |  {spotsArr[1]}  |  {spotsArr[2]}  ");
            Console.WriteLine("------------------");
            Console.WriteLine($"  {spotsArr[3]}  |  {spotsArr[4]}  |  {spotsArr[5]}  ");
            Console.WriteLine("------------------");
            Console.WriteLine($"  {spotsArr[6]}  |  {spotsArr[7]}  |  {spotsArr[8]}  ");
            Console.WriteLine("     |     |     ");

        }

        static void Welcome(int PlayerTurn, ref string p1x,ref string p2o)
        {
            Console.WriteLine("Welcome to poorman's TicTacToe");
            Console.WriteLine($"Player 1:X ({p1x})");
            Console.WriteLine($"Player 2:O ({p2o})");
            Console.WriteLine("\n");
            Console.WriteLine($"Current turn : {PlayerTurn}");
            Console.WriteLine("\n");
        }

        static int NextP(int Player)
        {
            if (Player.Equals(1))
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }
        static void Functionality(char[] spotsArr, int cPlayer)
        {
            bool Invalid = true;
            do
            {
                string Choice = Console.ReadLine();

                if (!string.IsNullOrEmpty(Choice) && (Choice.Equals("1") ||
                   Choice.Equals("2") ||
                   Choice.Equals("3") ||
                   Choice.Equals("4") ||
                   Choice.Equals("5") ||
                   Choice.Equals("6") ||
                   Choice.Equals("7") ||
                   Choice.Equals("8") ||
                   Choice.Equals("9")))
                {
                    

                    int.TryParse(Choice, out var spotsArrFunc);

                    char spotsArrC = spotsArr[spotsArrFunc - 1];

                    if (spotsArrC.Equals('X') || spotsArrC.Equals('O'))
                    {
                        Console.WriteLine("Spot already taken!");
                    }
                    else
                    {
                        spotsArr[spotsArrFunc - 1] = PChoice(cPlayer);

                        Invalid = false;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Move.");
                }

            } while (Invalid);
        }

        static char PChoice(int player)
        {
            if (player % 2 == 0)
            {
                return 'O';
            }
            return 'X';
        }
        static int WCheck(char[] spotsArr)
        {
            if (Draw(spotsArr))
            {
                return 2;
            }

            if (PWinC(spotsArr))
            {
                return 1;
            }
            
            return 0;
        }

        static bool Draw(char[] spotsArr)
        {
            return spotsArr[0] != '1' &&
                   spotsArr[1] != '2' &&
                   spotsArr[2] != '3' &&
                   spotsArr[3] != '4' &&
                   spotsArr[4] != '5' &&
                   spotsArr[5] != '6' &&
                   spotsArr[6] != '7' &&
                   spotsArr[7] != '8' &&
                   spotsArr[8] != '9';
        }

        static bool PWinC(char[] spotsArr)
        {
            if (PSimC(spotsArr, 0, 1, 2))
            {
                return true;
            }
            if (PSimC(spotsArr, 3, 4, 5))
            {
                return true;
            }
            if (PSimC(spotsArr, 6, 7, 8))
            {
                return true;
            }
            if (PSimC(spotsArr, 0, 3, 6))
            {
                return true;
            }
            if (PSimC(spotsArr, 1, 4, 7))
            {
                return true;
            }
            if (PSimC(spotsArr, 2, 5, 8))
            {
                return true;
            }
            if (PSimC(spotsArr, 0, 4, 8))
            {
                return true;
            }
            if (PSimC(spotsArr, 2, 4, 6))
            {
                return true;
            }

            return false;

        }

        static bool PSimC(char[] TspotsArr, int p1, int p2, int p3)
        {
            return TspotsArr[p1].Equals(TspotsArr[p2]) && TspotsArr[p2].Equals(TspotsArr[p3]);
        }
    }
}
