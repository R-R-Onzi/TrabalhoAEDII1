using System;
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

            /*BinaryReader pop = new BinaryReader(File.OpenRead(path));
            byte[] by = new byte[4];
            for (int i = 0; i < 620; i++)
            {

                string s = System.Text.Encoding.ASCII.GetString(pop.ReadBytes(1));
                Console.WriteLine(s);

            }*/



            Console.ReadKey();
            ConsoleColor s = ConsoleColor.Red;
            ConsoleColor foreground = ConsoleColor.Yellow;
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = s;
            do
            {
                Console.WriteLine("---------Menu---------");
                Console.Clear();
                Menus menu = new Menus();
                Console.WriteLine(menu);
                string entradadoUsuario = Console.ReadLine();
                menu.ParseAndDestroy(entradadoUsuario);
                

            } while (true);
        }
    }
}
