using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Plane
{
    static class Shop
    {
        public static void ShopMenu(Menu menu, SpaceShip F117)
        {
            Console.Clear();
            int price;
            menu.Draw();
            switch(menu.NameP)
            {
                case "MagineGun":
                    SetConsolCur(menu);
                    Bullet M = new MagineGun(0, 0);
                    M.ShowInfo();
                    Console.WriteLine("Your gold: {0}", F117.Gold);
                    if(Buy(menu))
                    {
                        if (F117.Gold >= M.Price)
                        {
                            F117.Gold -= M.Price;
                            F117.MainCanon = M;
                        }
                        else 
                        {
                            Console.WriteLine("Sorry. You haven't enough gold.");
                            Thread.Sleep(1500);
                        }
                    }
                    break;
                case "Blaster":
                    SetConsolCur(menu);
                    Bullet B = new Blaster(0, 0);
                    B.ShowInfo();
                    Console.WriteLine("Your gold: {0}", F117.Gold);
                    if (Buy(menu))
                    {
                        if (F117.Gold >= B.Price)
                        {
                            F117.Gold -= B.Price;
                            F117.MainCanon = B;
                        }
                        else
                        {
                            Console.WriteLine("Sorry. You haven't enough gold.");
                            Thread.Sleep(1500);
                        }
                    }
                    break;
                case "Laser":
                    SetConsolCur(menu);
                    Bullet L = new Laser(0, 0);
                    L.ShowInfo();
                    Console.WriteLine("Your gold: {0}", F117.Gold);
                    if (Buy(menu))
                    {
                        if (F117.Gold >= L.Price)
                        {
                            F117.Gold -= L.Price;
                            F117.MainCanon = L;
                        }
                        else
                        {
                            Console.WriteLine("Sorry. You haven't enough gold.");
                            Thread.Sleep(1500);
                        }
                    }
                    break;
                case "SubCanon":
                    price = 120;
                    SetConsolCur(menu);
                    Console.WriteLine("Allows you to use sub canon.\n\tPrice: {0}", price);
                    Console.WriteLine("Your gold: {0}", F117.Gold);
                    if (Buy(menu))
                    {
                        if (F117.Gold >= price)
                        {
                            F117.Gold -= price;
                            F117.SubCanon = new MagineGun(0,0);
                        }
                        else
                        {
                            Console.WriteLine("Sorry. You haven't enough gold.");
                            Thread.Sleep(1500);
                        }
                    }
                    break;
                case "Repair Kit":
                    price = 75;
                    SetConsolCur(menu);
                    Console.WriteLine("Repair your battleship.\n\tPrice: {0}", price);
                    Console.WriteLine("Your gold: {0}", F117.Gold);
                    if (Buy(menu))
                    {
                        if (F117.Gold >= price)
                        {
                            F117.Gold -= price;
                            F117.HP = F117.MaxHP;
                        }
                        else
                        {
                            Console.WriteLine("Sorry. You haven't enough gold.");
                            Thread.Sleep(1500);
                        }
                    }
                    break;
            }
            Console.Clear();
        }     
        public static void SetConsolCur(Menu menu)
        {
            Console.SetCursorPosition(0, menu.Name().Count() + 2);
        }
        public static bool Buy(Menu menu)
        {
            string buy = null;
            Console.SetCursorPosition(10, menu.Name().Count() + 10);
            Console.Write("Want to Buy: y/n: ");
            while (buy != "y" && buy != "n")
            {
                buy = Console.ReadLine();
            }
            return buy == "y" ? true : false;
        }
    }
}
