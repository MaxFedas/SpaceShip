using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plane
{
    static class CollisionCheck
    {
        struct shipCord
        {
            private int x;
            private int y;
            public int X
            {
                get { return x; }
                set { x = value; }
            }
            public int Y
            {
                get { return y; }
                set { y = value; }
            }
        }
        struct enemyCord
        {
            private int x;
            private int y;
            public int X
            {
                get { return x; }
                set { x = value; }
            }
            public int Y
            {
                get { return y; }
                set { y = value; }
            }
        }
        public static bool BooM (SpaceShip ship, Enemy en)
        {
            int temp_X = ship.Cord_X;
            int temp_Y = ship.Cord_Y;
            List<shipCord> shipListCord = new List<shipCord>();
            List<enemyCord> enemyListCord = new List<enemyCord>();
            shipCord s = new shipCord();
            enemyCord e = new enemyCord();
            for (int i = 0; i < ship.GetHeight; ++i)
            {
                temp_X = ship.Cord_X;
                for (int j = 0; j < ship.GetLength; ++j)
                {
                    if (ship.Matrix(i,j) != 0)
                    {                  
                        s.X = temp_X;
                        s.Y = temp_Y;
                        shipListCord.Add(s);
                    }
                    ++temp_X;
                }
                ++temp_Y;
            }
            temp_Y = en.GetY;
            for (int i = 0; i < en.GetHeight; ++i)
            {
                temp_X = en.GetX;
                for (int j = 0; j < en.GetWidth; ++j)
                {
                    if (en.Matrix(i, j) != 0)
                    {
                        e.X = temp_X;
                        e.Y = temp_Y;
                       enemyListCord.Add(e);
                    }
                    ++temp_X;
                }
                ++temp_Y;
            }
            foreach(enemyCord en_C in enemyListCord)
            {
                foreach (shipCord sp_C in shipListCord)
                {
                    if (en_C.X == sp_C.X && en_C.Y == sp_C.Y)
                        return true;
                }
            }
                return false;
        }

        public static bool BooM(SpaceShip ship, Bonus bns)
        {
            int temp_X = ship.Cord_X;
            int temp_Y = ship.Cord_Y;
            List<shipCord> shipListCord = new List<shipCord>();
            shipCord s = new shipCord();
            for (int i = 0; i < ship.GetHeight; ++i)
            {
                temp_X = ship.Cord_X;
                for (int j = 0; j < ship.GetLength; ++j)
                {
                    if (ship.Matrix(i, j) != 0)
                    {
                        s.X = temp_X;
                        s.Y = temp_Y;
                        shipListCord.Add(s);
                    }
                    ++temp_X;
                }
                ++temp_Y;
            }
                foreach (shipCord sp_C in shipListCord)
                {
                    if (bns.GetX == sp_C.X && bns.GetY == sp_C.Y)
                        return true;
                }
            return false;
        }
    }
}
