using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Collections;

namespace Trabalhosis
{
    class FazHash
    {
        public static void HashArk(LinkedList<IndiceHash>[] indiceHash)
        {




           
            FileStream le = new FileStream(Environment.CurrentDirectory + @"\main.dat",FileMode.Open);
            IndiceHash ind;
            byte[] po =new byte[2000];
            
            
            string aux,fim;
            
            long end = 0;
            do
            {

                le.Read(po, 0, 620);
                aux = new string(Encoding.UTF8.GetChars(po));
                fim = aux.Substring(506,10);
                fim = Regex.Replace(fim, @"[\D]", "");
                int has;
                int ava;
                try
                {
                    ava = Convert.ToInt32(fim);
                    ind = new IndiceHash(ava, end * 620);
                    has = MathB.Separator(ava, 6);
                    has = MathB.Hash(has);
                }
                catch (Exception)
                {
                    goto fim;
                }






                LinkedListNode<IndiceHash> nov = new LinkedListNode<IndiceHash>(ind);




                if (indiceHash[has] == null)
                {
                    indiceHash[has] = new LinkedList<IndiceHash>();
                    indiceHash[has].AddFirst(nov);
                }
                else
                {
                    indiceHash[has].AddLast(nov);
                }




            fim:
                end++;
                
            } while (le.Position!=le.Length);

            le.Close();
            
        }
    }
}
