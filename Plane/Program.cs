using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Plane
{
    enum Direction
        { up, right, down, left }
    class Program
    {
        static void Main()
        {
            //DateTime turnTimer = DateTime.Now;
           // DateTime prevTurnTimer = turnTimer;
           // int countTimer;
           // int prevCountTimer = 0;
            Menu mainMenu = new Menu("Start Game", "Controls");
            int tempCh = mainMenu.Draw();
            switch(mainMenu.NameP)
            {
                case "Controls":
                    Console.Clear();
                    Console.WriteLine("Move: by arrows\nFire: space\nTurn on/off subCanons (if available): tab\nShop: 1\n\n\tPress enter to continion...");
                    Console.Read();
                    break;
            }
            Console.Clear();
            Console.SetWindowSize(Map.Width + Map.InfoWidth, Map.Height);
            Console.SetBufferSize(Map.Width + Map.InfoWidth, Map.Height);
            //Console.BackgroundColor = ConsoleColor.DarkBlue;
            SpaceShip F117 = new SpaceShip(); // your battleship
            Direction direct = new Direction(); // направление движения
            //int cord_X = Map.Width / 2; // start position of ship
          //  int cord_Y = Map.Height - F117.GetHeight - 2; // start position of ship
            ulong timer = 0; 
            int max_amunition = 31; // запас патронов до перезарядки
            Bullet[] bullet = new Bullet[max_amunition];
            List<Enemy> enemys = new List<Enemy>();
            List<Bonus> bonus = new List<Bonus>();
            Menu shopMenu = new Menu("MagineGun", "Blaster", "Laser", "SubCanon", "Repair Kit", "Exit");
            int current_bullet = 0; // текущие количесто выстреляных патронов, обнуление каждую перезарядку
            int first_bullet = 0;
         //   ulong prev_timer = 0;
            ConsoleKeyInfo keypress;
           // keypress = Console.ReadKey(true);
            DeathStar en = new DeathStar();
            Scout sct = new Scout();
            Random rnd = new Random();
            int missed_enemy = 0;
            int max_to_miss = 30;
           // F117.SubCanon = new MagineGun(F117.GetSubCanonFirst_X, F117.GetSubCanon_Y);
           // F117.MainCanon = new MagineGun(F117.GetMainCanon_X, F117.GetMainCanon_Y);
            enemys.Add(en);
           // en.Drow();

            F117.Drow();
            F117.Info(current_bullet, max_amunition);
          //  countTimer = (turnTimer.Second + turnTimer.Minute * 60 + turnTimer.Hour * 60 * 60) * 1000 + turnTimer.Millisecond;
            do
            {
                timer++;
                
               // Thread.Sleep(100);
                if (Console.KeyAvailable)
                {
                    keypress = Console.ReadKey(true);
                   
                    //Console.Write(keypress.Key.ToString());
                    switch (keypress.Key.ToString())
                    {
                        case "DownArrow":
                            if (F117.Cord_Y < Map.Height - (F117.GetHeight + 1))
                            {
                                F117.Cord_Y += 1;
                                direct = Direction.down;
                            }
                            break;
                        case "UpArrow":
                            if (F117.Cord_Y != 0)
                            {
                                F117.Cord_Y -= 1;
                                //cord_Y--;
                                direct = Direction.up;
                            }
                            break;
                        case "LeftArrow":
                            if (F117.Cord_X != 0)
                            {
                                F117.Cord_X -= 1;
                                //cord_X--;
                                direct = Direction.left;
                            }
                            break;
                        case "RightArrow":
                            if (F117.Cord_X < Map.Width - (F117.GetLength + 1))
                            {
                                F117.Cord_X += 1;
                                //cord_X++;
                                direct = Direction.right;                              
                            }
                            break;
                        case "Tab":
                            F117.AvailableOfSubCanon = !F117.AvailableOfSubCanon;
                            break;
                        case "D1":
                            Shop.ShopMenu(shopMenu, F117);
                            //F117.MainCanon = new MagineGun(F117.GetMainCanon_X, F117.GetMainCanon_Y);
                            break;
                            /*
                        case "D2":
                            F117.MainCanon = new Blaster(F117.GetMainCanon_X, F117.GetMainCanon_Y);
                            break;
                        case "D3":
                            F117.MainCanon = new Laser(F117.GetMainCanon_X, F117.GetMainCanon_Y);
                            break;
                              */
                        case "Spacebar":
                            if (current_bullet < max_amunition - 1)
                            {
                                if (timer - F117.PrevMainCanonTimer >= F117.MainCanon.FireRate)
                                {
                                   // bullet[current_bullet] = new Bullet(F117.GetMainCanon_X, F117.GetMainCanon_Y, '*', 1000 /*Encoding.GetEncoding(437).GetChars(new byte[] { (byte)179 })[0]*/);
                                    switch (Convert.ToString(F117.MainCanon.GetType()))
                                    {
                                        case "Plane.Laser":
                                            bullet[current_bullet] = new Laser(F117.GetMainCanon_X, F117.GetMainCanon_Y);
                                            break;
                                        case "Plane.MagineGun":
                                            bullet[current_bullet] = new MagineGun(F117.GetMainCanon_X, F117.GetMainCanon_Y);
                                            break;
                                        case "Plane.Blaster":
                                            bullet[current_bullet] = new Blaster(F117.GetMainCanon_X, F117.GetMainCanon_Y);
                                            break;
                                    }
                                  //  bullet[current_bullet] = new Laser(F117.GetMainCanon_X, F117.GetMainCanon_Y);
                               
                                    current_bullet++;
                                    F117.PrevMainCanonTimer = timer;
                                }
                                if (current_bullet < max_amunition - 3 && F117.SubCanon != null)
                                {
                                    if (F117.AvailableOfSubCanon == true && (timer - F117.PrevSubCanonTimer >= F117.SubCanon.FireRate))
                                    {
                                        //bullet[current_bullet] = new Bullet(F117.GetSubCanonFirst_X, F117.GetSubCanon_Y, '.', 500);
                                        bullet[current_bullet] = new MagineGun(F117.GetSubCanonFirst_X, F117.GetSubCanon_Y);
                                        current_bullet++;
                                       // bullet[current_bullet] = new Bullet(F117.GetSubCanonSecond_X, F117.GetSubCanon_Y, '.', 500);
                                        bullet[current_bullet] = new MagineGun(F117.GetSubCanonSecond_X, F117.GetSubCanon_Y);
                                        current_bullet++;
                                        F117.PrevSubCanonTimer = timer;
                                    }
                                }
                                F117.Info(current_bullet, max_amunition);
                                /*
                                Console.SetCursorPosition(0, 0);
                                if (max_amunition-1 <= current_bullet)
                                    Console.Write("Bullet left: reload");
                                else
                                    Console.Write("Bullet left: {0,-6}", (max_amunition - 1 - current_bullet));
                                 */
                            }
                            break;
                    }
                   // F117.Drow(cord_X, cord_Y, direct);
                     F117.Drow(direct);
                    
                }
                if (timer % 150000 == 0 && enemys.Count < 10)
                //turnTimer = DateTime.Now;
              //  countTimer = (turnTimer.Second + turnTimer.Minute * 60 + turnTimer.Hour * 60 * 60) * 1000 + turnTimer.Millisecond;
               // if ((countTimer - prevCountTimer >= 100)  && enemys.Count < 10)
                {                    
                    switch(rnd.Next(2))
                    {
                        case 0:
                             en = new DeathStar();
                             enemys.Add(en);
                             break;
                        case 1:
                             sct = new Scout();
                             enemys.Add(sct);
                             break; 
                    }
                    //en = new DeathStar();
                    //enemys.Add(en);
                }
                for (int i = 0; i < enemys.Count(); ++i)
                {
                    //Console.SetCursorPosition(40, 0);
                    //Console.Write("{0, -15}", enemys[0].HP);
                    if (timer % enemys[i].Speed == 0)
                    //if ((countTimer - prevCountTimer) >= Convert.ToInt32(enemys[i].Speed))
                    {
                        enemys[i].Drow();
                    }
                    if (enemys[i].HP <= 0 )//если враг убит
                    {
                        F117.Score = enemys[i].Reward - enemys[i].GetY; // получаем очки
                        enemys[i].DrowClear();
                        if ((rnd.Next(100) < 20) && (bonus.Count() < 5)) // 20% шанс бонуса и их меньше 5
                        {
                            Bonus bns = new Bonus(enemys[i]);
                            bonus.Add(bns);
                        }
                        enemys.RemoveAt(i);//убираем его из листа
                      //  Console.SetCursorPosition(0, 30);
                        //Console.Write("Score: {0, -5}", F117.Score);
                        F117.Info(current_bullet, max_amunition);
                        break;
                    }
                    if (enemys[i].GetY == Map.Height - 1 - enemys[i].GetHeight) // если враг не был убит до конца карты
                    {
                        enemys[i].DrowClear();
                        missed_enemy++;
                        Console.SetCursorPosition(Map.Width + 3, 20);
                        Console.Write("Missed {0, -2} / {1, -2}", missed_enemy, max_to_miss);
                        enemys.RemoveAt(i);
                        break;
                    }
                    if ((enemys[i].GetY + enemys[i].GetHeight >= F117.Cord_Y) && (enemys[i].GetY <= F117.Cord_Y + F117.GetHeight)
                        && (enemys[i].GetX + enemys[i].GetWidth >= F117.Cord_X) && (enemys[i].GetX <= F117.Cord_X + F117.GetLength)) // проверка на столкновение
                    {
                       // Console.SetCursorPosition(40, 0);
                        //Console.Write(F117.HP);
                       // Console.Write(CollisionCheck.BooM(F117, enemys[i]));
                        if (CollisionCheck.BooM(F117, enemys[i]))
                        {
                            F117.HP -= enemys[i].Damage;
                            // Console.SetCursorPosition(40, 0);
                            //   Console.Write(F117.HP);
                            enemys[i].DrowClear();
                            enemys.RemoveAt(i);
                            F117.Drow();
                            F117.Info(current_bullet, max_amunition);
                            break;
                        }
                    }
                }
                for (int i = 0; i < bonus.Count(); ++i)
                {
                    if (timer % bonus[i].Speed == 0)
                    {
                        bonus[i].Drow();
                    }
                    if (bonus[i].GetY == Map.Height - 2)
                    {
                        bonus[i].Clear();
                        bonus.RemoveAt(i);
                       
                        break;
                    }
                    if ((bonus[i].GetY >= F117.Cord_Y) && (bonus[i].GetY <= F117.Cord_Y + F117.GetHeight)
                        && (bonus[i].GetX >= F117.Cord_X) && (bonus[i].GetX <= F117.Cord_X + F117.GetLength)) // проверка на взятие бонуса
                    {
                        // Console.SetCursorPosition(40, 0);
                      //  Console.Write(F117.Gold);
                        // Console.Write(CollisionCheck.BooM(F117, enemys[i]));
                        if (CollisionCheck.BooM(F117, bonus[i]))
                        {
                            F117.Gold += bonus[i].Gold;
                            // Console.SetCursorPosition(40, 0);
                             //  Console.Write(F117.Gold);
                            bonus[i].Clear();
                            bonus.RemoveAt(i);
                            F117.Drow();
                            F117.Info(current_bullet, max_amunition);
                            break;
                        }
                    }
                }
                    for (int j = first_bullet; j < current_bullet; ++j)
                    {
                        if (bullet[j] != null && (timer % (ulong)bullet[j].GetSpeed == 0))
                        {
                            bullet[j].DrowBullet();
                            foreach (Enemy e in enemys)
                            {
                                for (int h = 0; h < e.GetHeight; ++h)
                                {
                                    for (int w = 0; w < e.GetWidth; ++w)
                                    {
                                        if ((bullet[j].GetX == e.GetX + w) && (bullet[j].GetY == e.GetY + h))
                                        {
                                            e.HP = e.HP - bullet[j].Damage;
                                            bullet[j].ClearBullet();
                                            // bullet[j].DrowBulletNull();
                                            bullet[j].GetY = 0;
                                            w = e.GetWidth;
                                            h = e.GetHeight;
                                            // break;
                                        }
                                    }
                                }
                            }
                            if (bullet[j] != null && bullet[j].GetY == 0)
                            {
                                bullet[j].DrowBullet();
                                bullet[j] = null;
                                if (j == max_amunition - 2)
                                {
                                    current_bullet = 0;
                                   // Console.SetCursorPosition(0, 0);
                                    //Console.Write("Bullet left: {0,-6}", (max_amunition - 1 - current_bullet));
                                }
                            }
                        }
                    }
                  //prevCountTimer = countTimer;
                  //turnTimer = DateTime.Now;
                  //countTimer = (turnTimer.Second + turnTimer.Minute * 60 + turnTimer.Hour * 60 * 60) * 1000 + turnTimer.Millisecond;
               
               // Console.Write(Console.CursorTop);
               // Console.Write(timer);
                   
            } while (/*keypress.Key.ToString() != "Escape"*/F117.HP > 0 && missed_enemy < max_to_miss);
            Console.SetCursorPosition((Map.Width / 2)-10, Map.Height / 2);
            Console.WriteLine("GameOver! You earned {0} points! Press Ecs to exit!", F117.Score);
            do
            {
                keypress = Console.ReadKey(true);
            } while (keypress.Key.ToString() != "Escape");
        }
    }
}