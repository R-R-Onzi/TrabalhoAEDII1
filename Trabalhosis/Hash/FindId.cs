using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalhosis
{
    class CheeseBacon : IMenuAction
    {
   
        public void Run()
        {
            Console.Clear();
            Console.WriteLine("DIGITE A ID: ");
            int end = 0; 
            long  tri, id = Convert.ToInt64(Console.ReadLine());

            StreamReader le = new StreamReader(File.OpenRead(Environment.CurrentDirectory + @"\main.dat"));
            byte[] hashtags = new byte[2000];
            string aux, fim;
            bool x = true;

            do
            {
                le.BaseStream.Seek(0,SeekOrigin.Current);
                aux = le.ReadLine();
                fim = aux.Substring(1, 20);
                fim.Trim();
                tri =  Convert.ToInt64(fim);
                if (id == tri)
                {
                    Console.WriteLine(aux);
                    x = false;
                    Console.ReadKey();
                }
                else if (tri >= id)
                {
                    Console.WriteLine("Id não existente");
                    x = false;
                    Console.ReadKey();
                }
                le.ReadLine();
            } while (x);

            le.Close();
        }
    }
}
