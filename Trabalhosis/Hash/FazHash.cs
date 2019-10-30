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
        public static Hashtable HashArk()
        {




            Hashtable hashtable = new Hashtable();
            FileStream le = new FileStream(Environment.CurrentDirectory + @"\main.dat",FileMode.Open);
            IndiceHash ind;
            byte[] po =new byte[2000];
            IndiceHash indiceHash;
            string aux,fim;
            
            int end = 0;
              do
            {
                
                le.Read(po, 0, 620);
                aux = new string(Encoding.UTF8.GetChars(po));
                fim = aux.Substring(506,10);
                fim = Regex.Replace(fim, @"[\D]", "");
                
                try
                {

                    int ava = Convert.ToInt32(fim);
                    uint ia = Convert.ToUInt32(ava);
                    uint thy = ia;
                    
                    indiceHash = new IndiceHash(ava,620*end);
                    hashtable.Add(ia,indiceHash);
                    
                    
                }
                catch (Exception)
                {


                }
                end++;
                
            } while (le.CanRead);

            le.Close();
            return hashtable;
        }
    }
}
