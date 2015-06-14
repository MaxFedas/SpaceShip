using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plane
{
    class Enemy
    {
        protected int _cord_X;
        protected int _cord_Y;
        protected int[,] _form_matrix;
        protected int _height;
        protected int _width;
        protected ulong _speed;
        protected int _HP;
        protected int _maxHP;
        protected int _rewards;
        protected int _collisionDmg;
        //protected string _name;

        public Enemy()
        {          
          // _form_matrix = new int[_height, _width];
          // Random rnd = new Random();
          // _cord_X = rnd.Next((Map.Width - _width)) + 2;
          // _cord_Y = 0;
         //   Console.Write("Enemy");
        }

        public int Damage
        {
            get { return _collisionDmg; }
        }
        public int Reward
        {
            get { return _rewards; }
        }
        public ulong Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }
        public int GetX
        {
            get { return _cord_X; }
        }
        public int GetY
        {
            get { return _cord_Y; }
        }
        public int GetHeight
        {
            get { return _height; }
        }
        public int GetWidth
        {
            get { return _width; }
        }
        public int HP
        {
            get { return _HP; }
            set { _HP = value; }
        }
        public int MaxHP
        {
            get { return this._maxHP; }
        }

        public int Matrix(int i, int j)
        {
            return _form_matrix[i, j];
        }
        public void Drow()
        {
            if (_cord_Y < (Map.Height - 1 - _height))
            {
                for (int i = 0; i < _height; ++i)
                {
                    Console.SetCursorPosition(_cord_X, _cord_Y + i);
                    for (int j = 0; j < _width; ++j)
                    {
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                }
                ++_cord_Y;

                if (_HP < (_maxHP / 100 * 30))
                    Console.ForegroundColor = ConsoleColor.Red;
                else if (_HP < (_maxHP / 100 * 70))
                    Console.ForegroundColor = ConsoleColor.Yellow;
                else
                    Console.ForegroundColor = ConsoleColor.Magenta;

                for (int i = 0; i < _height; ++i)
                {
                    Console.SetCursorPosition(_cord_X, _cord_Y + i);
                    for (int j = 0; j < _width; ++j)
                    {
                        if (_form_matrix[i,j] != 0)
                        {
                            Console.SetCursorPosition(_cord_X + j, _cord_Y + i);
                            Console.Write(Convert.ToChar(_form_matrix[i, j]));
                        }     
                    }
                    Console.WriteLine();
                }
               Console.ResetColor();
            }
          //  Console.SetCursorPosition(90, 2);
           // Console.Write("HP: {0, -4}", this.HP);
        }
        public void DrowClear()
        {
                for (int i = 0; i < _height; ++i)
                {
                    Console.SetCursorPosition(_cord_X, _cord_Y + i);
                    for (int j = 0; j < _width; ++j)
                    {
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                }         
        }
    }
    class DeathStar : Enemy
    {
        public DeathStar()
        {
            _maxHP = _HP = 1000;
            _height = 5;
            _width = 5;
            _speed = 20000;
            _form_matrix = new int[_height, _width];
            _form_matrix[0, 2] = 42;
            _form_matrix[1, 2] = 42;
            _form_matrix[2, 0] = _form_matrix[2, 1] = _form_matrix[2, 3] = _form_matrix[2, 4] = 42;
            _form_matrix[3, 2] = _form_matrix[4, 2] = 42;
            _form_matrix[2, 2] = 2;
            _form_matrix[1, 1] = _form_matrix[3, 3] = 92;
            _form_matrix[3, 1] = _form_matrix[1, 3] = 47;
            Random rnd = new Random();
            _cord_X = rnd.Next((Map.Width - _width * 2)) + 3;
            _cord_Y = 0;
            _rewards = 120;
            _collisionDmg = 350;
       //     Console.Write("DeathStar");
        }
    }
  class Scout : Enemy
    {
       
        public Scout()
        {
            _maxHP = _HP = 700;
            _height = 3;
            _width = 3;
            _speed = 15000;
            _form_matrix = new int[_height, _width];
            _form_matrix[0, 1] = 30;
            _form_matrix[2, 1] = 31;
            _form_matrix[1, 0] = 91;
            _form_matrix[1, 2] = 93;
            _form_matrix[1, 1] = 15;
            Random rnd = new Random();
            _cord_X = rnd.Next((Map.Width - _width * 2)) + 2;
            _cord_Y = 0;
            _rewards = 90;
            _collisionDmg = 500;
         //   Console.Write("Scout");
        }
    }
}
