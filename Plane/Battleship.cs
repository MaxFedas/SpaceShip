using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plane
{
    class SpaceShip
    {
        private const int _HEIGHT = 5, _LENGTH = 9;
        private int[,] matrix = new int[_HEIGHT, _LENGTH];
        private char c;
        private int mainCanon_X = 4, mainCanon_Y = 0;
        private int subCanonFirst_X = 1, subCanonSecond_X = 7, subCanon_Y = 2;
        private bool availableOfSubCanon = false;
        private ulong _prevMainCanonTimer = 0;
        private ulong _prevSubCanonTimer = 0;
        private Bullet _mainCanon;
        private Bullet _subCanon;
        private int _score;
        private int _hp;
        private int _maxHp;
        private int _cord_X;
        private int _cord_Y;
        private int _gold;

        public int Matrix(int i, int j)
        {
            return matrix[i, j];
        }
    
        public int Gold
        {
            get { return _gold; }
            set { _gold = value; }
        }
        public int Cord_X
        {
            get { return _cord_X; }
            set { _cord_X = value; }
        }
        public int Cord_Y
        {
            get { return _cord_Y; }
            set { _cord_Y = value; }
        }
        public int HP
        {
            get { return _hp; }
            set { _hp = value; }
        }
        public int MaxHP
        {
            get { return _maxHp; }
            set { _maxHp = value; }
        }
        public int Score
        {
            get { return _score; }
            set { _score += value; }
        }
        public Bullet MainCanon
        {
            get { return _mainCanon; }
            set { _mainCanon = value; }
        }
        public Bullet SubCanon
        {
            get { return _subCanon; }
            set { _subCanon = value; }
        }
        public ulong PrevMainCanonTimer
        {
            set { this._prevMainCanonTimer = value; }
            get { return this._prevMainCanonTimer; }
        }
        public ulong PrevSubCanonTimer
        {
            set { this._prevSubCanonTimer = value; }
            get { return this._prevSubCanonTimer; }
        }
        public int GetSubCanonFirst_X
        {
            get { return subCanonFirst_X; }
        }
        public int GetSubCanonSecond_X
        {
            get { return subCanonSecond_X; }
        }
        public int GetSubCanon_Y
        {
            get { return subCanon_Y; }
        }
        public bool AvailableOfSubCanon
        {
            set { availableOfSubCanon = value; }
            get { return availableOfSubCanon; }
        }
        public int GetMainCanon_X
        {
            get { return mainCanon_X; }
        }
        public int GetMainCanon_Y
        {
            get { return mainCanon_Y; }
        }
        public int GetHeight
        {
            get { return _HEIGHT; }
        }
        public int GetLength
        {
            get { return _LENGTH; }
        }
        public SpaceShip()
        {
            matrix[0, 4] = 30;
            matrix[1, 4] = 223;
            matrix[1, 3] = 220;
            matrix[1, 5] = 220;
            matrix[2, 3] = matrix[2, 4] = matrix[2, 5] = 219;
            matrix[2, 1] = matrix[2, 7] = 179;
            matrix[2, 2] = matrix[2, 6] = 220;
            matrix[3, 1] = matrix[3, 2] = matrix[3, 4] = matrix[3, 6] = matrix[3, 7] = 219;
            matrix[3, 3] = matrix[3, 5] = 223;
            matrix[3, 0] = 220;
            matrix[3, 8] = 220;
            matrix[4, 4] = 223;
            matrix[4, 3] = matrix[4, 5] = 220;
            _mainCanon = new MagineGun(mainCanon_X, mainCanon_Y);
            //_subCanon = new MagineGun(subCanonFirst_X, subCanon_Y);
            _subCanon = null;
            _maxHp = _hp = 1000;
            _cord_X = Map.Width / 2;
            _cord_Y = Map.Height - _HEIGHT - 3;
            _gold = 750; 
        }
        public void Drow(int x, int y, Direction direct)
        {
            mainCanon_X = x + 4;
            mainCanon_Y = y;
            subCanonFirst_X = x + 1;
            subCanonSecond_X = x + 7;
            subCanon_Y = y + 2;
            int temp_y = y;
            int temp_x = x;
            int temp_x_prev;
            switch (direct)
            {
                case Direction.down:
                    --y;
                    break;
                case Direction.up:
                    ++y;
                    break;
                case Direction.left:
                    ++x;
                    break;
                case Direction.right:
                    --x;
                    break;
            }
            temp_x_prev = x;
            for (int i = 0; i < _HEIGHT; ++i)
            {
                Console.SetCursorPosition(x, y);
                for (int j = 0; j < _LENGTH; ++j)
                {
                    c = Encoding.GetEncoding(437).GetChars(new byte[] { (byte)matrix[i, j] })[0];
                    if (matrix[i, j] != 0)
                    {
                        Console.Write(" ");
                        ++x;
                    }
                    else
                    {
                        ++x;
                        Console.SetCursorPosition(x, y);
                    }
                }
                ++y;
                x = temp_x_prev;
                Console.WriteLine();
            }
            y = temp_y;

            for (int i = 0; i < _HEIGHT; ++i)
            {
                x = temp_x;
                Console.SetCursorPosition(x, y);
                for (int j = 0; j < _LENGTH; ++j)
                {
                    c = Encoding.GetEncoding(437).GetChars(new byte[] { (byte)matrix[i, j] })[0];
                    if (matrix[i, j] != 0)
                    {
                        Console.Write(c);
                        x++;
                    }
                    else
                    {
                        x++;
                        Console.SetCursorPosition(x, y);
                    }
                }
                ++y;
                Console.WriteLine();
            }
        }

        public void Drow(Direction direct)
        {
            int x = _cord_X;
            int y = _cord_Y;
            mainCanon_X = x + 4;
            mainCanon_Y = y;
            subCanonFirst_X = x + 1;
            subCanonSecond_X = x + 7;
            subCanon_Y = y + 2;
            int temp_y = y;
            int temp_x = x;
            int temp_x_prev;
            switch (direct)
            {
                case Direction.down:
                    --y;
                    break;
                case Direction.up:
                    ++y;
                    break;
                case Direction.left:
                    ++x;
                    break;
                case Direction.right:
                    --x;
                    break;
            }
            temp_x_prev = x;
            for (int i = 0; i < _HEIGHT; ++i)
            {
                Console.SetCursorPosition(x, y);
                for (int j = 0; j < _LENGTH; ++j)
                {
                    c = Encoding.GetEncoding(437).GetChars(new byte[] { (byte)matrix[i, j] })[0];
                    if (matrix[i, j] != 0)
                    {
                        Console.Write(" ");
                        ++x;
                    }
                    else
                    {
                        ++x;
                        Console.SetCursorPosition(x, y);
                    }
                }
                ++y;
                x = temp_x_prev;
                Console.WriteLine();
            }
            y = temp_y;

            for (int i = 0; i < _HEIGHT; ++i)
            {
                x = temp_x;
                Console.SetCursorPosition(x, y);
                for (int j = 0; j < _LENGTH; ++j)
                {
                    c = Encoding.GetEncoding(437).GetChars(new byte[] { (byte)matrix[i, j] })[0];
                    if (matrix[i, j] != 0)
                    {
                        Console.Write(c);
                        x++;
                    }
                    else
                    {
                        x++;
                        Console.SetCursorPosition(x, y);
                    }
                }
                ++y;
                Console.WriteLine();
            }
        }

        public void Drow()
        {
            int x = _cord_X;
            int y = _cord_Y;
            mainCanon_X = x + 4;
            mainCanon_Y = y;
            subCanonFirst_X = x + 1;
            subCanonSecond_X = x + 7;
            subCanon_Y = y + 2;
            int temp_y = y;
            int temp_x = x;
            int temp_x_prev;
            temp_x_prev = x;
            for (int i = 0; i < _HEIGHT; ++i)
            {
                Console.SetCursorPosition(x, y);
                for (int j = 0; j < _LENGTH; ++j)
                {
                    c = Encoding.GetEncoding(437).GetChars(new byte[] { (byte)matrix[i, j] })[0];
                    if (matrix[i, j] != 0)
                    {
                        Console.Write(" ");
                        ++x;
                    }
                    else
                    {
                        ++x;
                        Console.SetCursorPosition(x, y);
                    }
                }
                ++y;
                x = temp_x_prev;
                Console.WriteLine();
            }
            y = temp_y;

            for (int i = 0; i < _HEIGHT; ++i)
            {
                x = temp_x;
                Console.SetCursorPosition(x, y);
                for (int j = 0; j < _LENGTH; ++j)
                {
                    c = Encoding.GetEncoding(437).GetChars(new byte[] { (byte)matrix[i, j] })[0];
                    if (matrix[i, j] != 0)
                    {
                        Console.Write(c);
                        x++;
                    }
                    else
                    {
                        x++;
                        Console.SetCursorPosition(x, y);
                    }
                }
                ++y;
                Console.WriteLine();
            }
        }

        public void Info(int current_bullet, int max_bullet)
        {
            int temp_X = Map.Width + 3;
            int temp_Y = 5;
            Console.SetCursorPosition(temp_X, temp_Y++);
            Console.Write("Your HP: {0, -5}", _hp);
            Console.SetCursorPosition(temp_X, temp_Y++);
            Console.Write("Score: {0, -7}", _score);
            Console.SetCursorPosition(temp_X, temp_Y++);
            Console.Write("Your gold: {0, -5}", _gold);
            if (_subCanon != null && availableOfSubCanon == true)
            {
                Console.SetCursorPosition(temp_X, temp_Y++);
                Console.Write("Sub Canon:{0, 9}", "turn-on");
            }
            else
            {
                Console.SetCursorPosition(temp_X, temp_Y++);
                Console.Write("Sub Canon:{0, 9}","turn-off");
            }
            temp_Y++;
            Console.SetCursorPosition(temp_X, temp_Y++);
            if (max_bullet - 1 <= current_bullet)
                Console.Write("Bullet left: reload");
            else
                Console.Write("Bullet left: {0,-6}", (max_bullet - 1 - current_bullet));

        }
        
    }
}
