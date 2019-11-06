using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalhosis.MongoArqs
{
    class Mongo : IMenuAction
    {
        public void Run()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.Black;
            do
            {

                Console.Clear();
                MenuM menu = new MenuM();
                Console.WriteLine(menu);
                string entradadoUsuario = Console.ReadLine();
                menu.ParseAndDestroy(entradadoUsuario);


            } while (true);
        }
    }
}
