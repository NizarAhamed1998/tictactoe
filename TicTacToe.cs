using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TicTacToeGame
{
    public class TicTacToe
    {
        List<TicTacToe> entrylist = new List<TicTacToe>();
        char[] _arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', };
        int[] _movesArray = { 0, 0, 0 };
        int state = 0;
        bool flag = true;
        string _player;
        int _point;
        int _totalMovesCount;
        int _xMovesCount;
        int _oMovesCount;

        public int OMovesCount
        {
            get { return _oMovesCount; }
            set { _oMovesCount = value; }
        }
        public int TotalMovesCount
        {
            get { return _totalMovesCount; }
            set { _totalMovesCount = value; }
        }


        public int XMovesCount
        {
            get { return _xMovesCount; }
            set { _xMovesCount = value; }
        }
        public string Player
        {
            get { return _player; }
            set { _player = value; }
        }


        public int Point
        {
            get { return _point; }
            set { _point = value; }
        }
        public int State
        {
            get { return state; }
            set { state = value; }
        }





        public void markboard(TicTacToe entry)
        {
            if (flag)
            {
                entrylist.Add(new TicTacToe() { Player = entry.Player, Point = entry.Point, TotalMovesCount = entry.TotalMovesCount, XMovesCount = entry.XMovesCount, OMovesCount = entry.OMovesCount });

            }
            _arr[entry.Point] = Convert.ToChar(entry.Player);
            _movesArray[0] = entry.TotalMovesCount;
            _movesArray[1] = entry.XMovesCount;
            _movesArray[2] = entry.OMovesCount;
            State = checkWin();
        }

        public string view()
        {
            return string.Format("Total_Moves:{0}\tX_Moves:{1}\tO_Moves:{2}\n     |     |      \n  {3}  |  {4}  |  {5}\n_____|_____|_____ \n     |     |      \n  {6}  |  {7}  |  {8}\n_____|_____|_____ \n     |     |      \n  {9}  |  {10}  |  {11}\n     |     |      ",
                                   _movesArray[0], _movesArray[1], _movesArray[2], _arr[0], _arr[1], _arr[2], _arr[3], _arr[4], _arr[5], _arr[6], _arr[7], _arr[8]);
        }
        public void replay()
        {
            flag = false;
            int num = 48;
            for (int i = 0; i < _arr.Length; i++)
            {

                _arr[i] = Convert.ToChar(num);
                num++;
            }
            int listCount = entrylist.Count();
            for (int i = 0; i < listCount; i++)
            {

                Console.Clear();
                TicTacToe val = entrylist[i];
                markboard(new TicTacToe() { Player = val.Player, Point = val.Point, TotalMovesCount = val.TotalMovesCount, XMovesCount = val.XMovesCount, OMovesCount = val.OMovesCount });
                Console.WriteLine(view());
                Thread.Sleep(3000);
            }
            Console.WriteLine(winOrdraw());
            flag = true;
        }
        public void goback()
        {
            flag = false;
            int repvalcount = entrylist.Count();
            int remlistCount = entrylist.Count() - 1;
            TicTacToe removeval = entrylist[remlistCount];
            entrylist.Remove(removeval);
            for (int i = 0; i < entrylist.Count(); i++)
            {
                TicTacToe val = entrylist[i];
                markboard(new TicTacToe () { Player = val.Player, Point = val.Point, TotalMovesCount = val.TotalMovesCount, XMovesCount = val.XMovesCount, OMovesCount = val.OMovesCount });
            }
            int num = repvalcount + 47;
            _arr[entrylist.Count()] = Convert.ToChar(num);
            //Console.Clear();
            //Console.WriteLine(view());
            flag = true;
        }
        public int checkWin()
        {

            if (_arr[0] == _arr[1] && _arr[1] == _arr[2])
            {
                return 1;
            }

            else if (_arr[3] == _arr[4] && _arr[4] == _arr[5])
            {
                return 1;
            }

            else if (_arr[6] == _arr[7] && _arr[7] == _arr[8])
            {
                return 1;
            }

            else if (_arr[0] == _arr[3] && _arr[3] == _arr[6])
            {
                return 1;
            }

            else if (_arr[1] == _arr[4] && _arr[4] == _arr[7])
            {
                return 1;
            }

            else if (_arr[2] == _arr[5] && _arr[5] == _arr[8])
            {
                return 1;
            }

            else if (_arr[0] == _arr[4] && _arr[4] == _arr[8])
            {
                return 1;
            }
            else if (_arr[2] == _arr[4] && _arr[4] == _arr[6])
            {
                return 1;
            }

            else if (_arr[0] != '0' && _arr[1] != '1' && _arr[2] != '2' && _arr[3] != '3' && _arr[4] != '4' && _arr[5] != '5' && _arr[6] != '6' && _arr[7] != '7' && _arr[8] != '8')
            {
                return -1;
            }

            else
            {
                return 0;
            }
        }
        public string winOrdraw()
        {
            string playerwin = "";
            int count = entrylist.Count() - 1;
            TicTacToe val = entrylist[count];
            playerwin = val.Player;

            string x = "";
            if (State == 1)
            {
                x = "Player  " + playerwin + "  Win";
            }
            else if (State == -1)
            {
                x = "Match Draw";
            }
            return x;
        }
        public string checkPlace(int n)
        {
            if (_arr[n] == Convert.ToChar(48 + n))
            {
                return "ok";
            }
            else
            {
                TicTacToe val = entrylist[n];
                return string.Format("sorry that place is already marked by {0} player", val.Player);
            }
        }
    }
  
}
