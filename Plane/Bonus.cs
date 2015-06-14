using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plane
{
    class Bonus
    {
        private char _c;
        private int _gold;
        private ulong _speed;
        private int _x;
        private int _y;

        public int GetX
        {
            get { return this._x; }
        }
        public int GetY
        {
            get { return this._y; }
        }
        public int Gold
        {
            get { return this._gold; }
        }
        public ulong Speed
        {
            get { return this._speed; }
        }

        public Bonus(Enemy en)
        {
            this._speed = en.Speed;
            this._c = '$';
            Random rnd = new Random();
            this._gold = rnd.Next(20) + 20;
            this._x = en.GetX + en.GetWidth / 2;
            this._y = en.GetY + en.GetHeight / 2;
        }
        public void Drow()
        {
            if (this._y != (Map.Height - 2))
            {
                Console.SetCursorPosition(this._x, this._y++);
                Console.Write(" ");
                Console.SetCursorPosition(this._x, this._y);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(_c);
                Console.ResetColor();
            }
            else
            {
                Console.SetCursorPosition(this._x, this._y);
                Console.Write(" ");
            }
        }
        public void Clear()
        {
            Console.SetCursorPosition(this._x, this._y);
            Console.Write(" ");
        }

    }
}
