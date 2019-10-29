using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net.Sockets;

namespace Trabalhosis
{
    class FazHash
    {
        public static void HashArk()
        {
         
            DateTime now;
            
            BinaryWriter a = new BinaryWriter(File.OpenWrite(Environment.CurrentDirectory + @"\Hash.dat"));
            FileStream le = new FileStream(Environment.CurrentDirectory + @"\main.dat",FileMode.Open);
            HashSet<IndiceHash> ind = new HashSet<IndiceHash>();
            byte[] po =new byte[2000];
            IndiceHash indiceHash;
            string aux,fim;
            
            int end = 0;
              do
            {

                le.Read(po, 0, 641);
                aux = new string(Encoding.UTF8.GetChars(po));
                fim = aux.Substring(21,20)+"fim";
                /* try
                 {
                     now = Convert.ToDateTime(fim);
                     indiceHash = new IndiceHash(now,)
                     ind.Add();
                 }
                 catch (Exception)
                 {

                     throw;
                 }*/
                Console.WriteLine(fim);
                Console.ReadKey();
                end++;
                
            } while (le.CanRead);

            le.Close();
            
        }
    }
}
