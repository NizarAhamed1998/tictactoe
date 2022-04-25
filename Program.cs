using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TicTacToeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToe ttt = new TicTacToe();



            int totalcount = 0;
            int xcount = 0;
            int ocount = 0;
            bool flag = true;
            do
            {
                Console.Clear();
                Console.WriteLine(ttt.view());
                string val = "";
                if (flag)
                {
                    val = "X";
                    xcount++;
                    flag = false;
                }
                else
                {
                    val = "O";
                    ocount++;
                    flag = true;
                }
                Console.Write("Enter your choice:value or goback");
                Console.WriteLine("\t {0} Turn", val);
                string getvalue = Console.ReadLine();
                int intvalue = 9;
                if (getvalue.Length == 1)
                {

                    string s = ttt.checkPlace(int.Parse(getvalue));
                    if (s == "ok")
                    {
                        intvalue = int.Parse(getvalue);
                    }
                    else
                    {
                        Console.WriteLine(s);
                        intvalue = 9;
                        if (val == "X")
                        {
                            xcount--;
                            flag = true;
                        }
                        else
                        {
                            ocount--;
                            flag = false;
                        }
                        Thread.Sleep(2000);
                    }

                }
                if (intvalue >= 0 && intvalue <= 8)
                {
                    totalcount = xcount + ocount;
                    
                    ttt.Player = val;
                    ttt.Point = Convert.ToInt32(getvalue);
                    ttt.TotalMovesCount = totalcount;
                    ttt.XMovesCount = xcount;
                    ttt.OMovesCount = ocount;
                    ttt.markboard(ttt);

                }
                else if (getvalue == "goback")
                {
                    xcount--;
                    ocount--;
                    ttt.goback();

                }
            } while (ttt.State != 1 && ttt.State != -1);
            Console.Clear();
            Console.WriteLine(ttt.view());
            Console.WriteLine(ttt.winOrdraw());
            Console.WriteLine("if you want to replay type replay");
            string replay = Console.ReadLine();
            if (true)
            {
                ttt.replay();
            }           
        }
       
    }
    
}
