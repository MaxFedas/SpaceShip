using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plane
{
    class Menu
    {
        private string[] name;
        private int numb;
        private int choice;

        public Menu(params string[] str)
        {
            this.numb = str.Count();
            this.name = str;
            this.choice = 0;
        }
        public string[] Name()
        {
            return name;
        }
        public string NameP
        {
            get { return this.name[this.choice]; }
        }
        public int Draw()
        {
            foreach (string str in name)
            {
                Console.WriteLine("     {0}", str);
            }
            this.Choice();
            return choice;
        }
        public void Choice()
        {
            ConsoleKeyInfo keypress;
            bool exit_flag = false;
            while (!exit_flag)
            {

                Console.SetCursorPosition(0, choice);
                Console.WriteLine(Convert.ToChar(26));
                keypress = Console.ReadKey(true);
                switch (keypress.Key.ToString())
                {
                    case "DownArrow":
                        Console.SetCursorPosition(0, choice);
                        Console.WriteLine(" ");
                        if (choice == name.Count() - 1)
                            choice = 0;
                        else
                            choice++;
                        break;
                    case "UpArrow":
                        Console.SetCursorPosition(0, choice);
                        Console.WriteLine(" ");
                        if (choice == 0)
                            choice = name.Count() - 1;
                        else
                            choice--;
                        break;
                    case "Enter":
                        exit_flag = true;
                        break;
                }
            }
        }
    }
}
