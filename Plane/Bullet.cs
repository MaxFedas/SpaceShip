using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plane
{
    class Bullet
    {
        protected int _cord_X;
        protected int _cord_Y;
        protected int _speed;
        protected int _damage;
        protected char _c; 
        protected ulong _fireRate;
        protected int _price;

        public int Price
        {
            get { return _price; }
        }
        public ulong FireRate
        {
            get { return _fireRate; }
        }
        public int Damage
        {
            get { return _damage; }
        }

        public int GetSpeed
        {
            get { return _speed; }
        }
        public int GetY
        {
            get { return _cord_Y; }
            set { _cord_Y = value; }
        }
        public int GetX
        {
            get { return _cord_X; }
        }
        public Bullet()
        { }

        public void ShowInfo()
        {
            Console.WriteLine("Damage: {0}\nSpeed: {1} (how long bullet is fly to target)\nFire Rate: {2} (show how time need to reload between shots)\n\tPrice: {3}", this._damage, this._speed, this._fireRate, this._price);
        }
        public Bullet(int x, int y)
        {
          //this._fireRate = 8000;
          //this._speed = 500;
          //this._c = '.';
          //this._damage = 80;
            this._cord_X = x;
            this._cord_Y = y-1;
        }
        public Bullet(int x, int y, char c, int speed)
        {
            _damage = 150;
            this._cord_X = x;
            this._cord_Y = y - 1;
            _c = c;
            this._speed = speed;
        }
        public void DrowBullet()
        {
                if (_cord_Y != 0)
                {
                    Console.SetCursorPosition(_cord_X, _cord_Y--);
                    Console.Write(" ");
                    Console.SetCursorPosition(_cord_X, _cord_Y);
                    Console.Write(_c);                 
                }
                else
                {
                    Console.SetCursorPosition(_cord_X, _cord_Y);
                    Console.Write(" ");
                }
        }
        public void ClearBullet()
        {
            Console.SetCursorPosition(_cord_X, _cord_Y);
            Console.Write(" ");
        }
        public void DrowBulletNull()
        {       
             Console.SetCursorPosition(_cord_X, _cord_Y+1);
             Console.Write(" ");           
        }
       // public void DrowBulletDiagonal(SpaceShip target)
       // {
       //     bool isMoreHoriz;
       //     int temp
       //     if (_cord_Y != target.GetMainCanon_Y && _cord_X != target.GetMainCanon_X)
       //     {
       //
       //     }
       // }
        //public int GetBulletY
        //{
        //    get { return _cord_Y; }
        //}
    }
    class MagineGun : Bullet
    {
        public MagineGun(int x, int y)
        {
            this._fireRate = 8000;
            this._speed = 500;
            _c = '.';
            this._damage = 80;
            this._cord_X = x;
            this._cord_Y = y-1;
            this._price = 50;
        }
    }
    class Blaster : Bullet
    {
        public Blaster(int x, int y)
        {
            this._fireRate = 35000;
            this._speed = 1000;
            _c = '*';
            this._damage = 250;
            this._cord_X = x;
            this._cord_Y = y-1;
            this._price = 90;
        }
    }
    class Laser : Bullet
    {
        public Laser(int x, int y)
        {
            this._fireRate = 45000;
            this._speed = 700;
            _c = Encoding.GetEncoding(437).GetChars(new byte[] { (byte)179 })[0];
            this._damage = 450;
            this._cord_X = x;
            this._cord_Y = y - 1;
            this._price = 250;
        }
    }
   
}
