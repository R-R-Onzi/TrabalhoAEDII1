﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Trabalhosis
{
    class Program
    {
        static void Main(string[] args)
        { 

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Magenta;
            do
            {
                
                Console.Clear();
                Menus menu = new Menus();
                Console.WriteLine(menu);
                string entradadoUsuario = Console.ReadLine();
                menu.ParseAndDestroy(entradadoUsuario);
                

            } while (true);
        }
    }
}
