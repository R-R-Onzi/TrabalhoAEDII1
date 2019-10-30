using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Trabalhosis
{
    class CheeseBacon : IMenuAction
    {
        public void Run()
        {
            Hashtable ind;
            ind = FazHash.HashArk();
            IndiceHash indice;
            Console.WriteLine("Digite a data");
            string aux3 = Console.ReadLine();
            aux3= Regex.Replace(aux3, @"[\D]", "");
            long esse = Convert.ToInt64(aux3);
            indice = (IndiceHash)ind[esse];
            FileStream le = new FileStream(Environment.CurrentDirectory + @"\main.dat", FileMode.Open);
            le.Seek(indice.pos,0);
           
            byte[] po = new byte[2000];
            le.Read(po, 0, 620);
            aux3 = new string(Encoding.UTF8.GetChars(po));
            Console.WriteLine(aux3);
            Console.ReadKey();
        }
    }
}
