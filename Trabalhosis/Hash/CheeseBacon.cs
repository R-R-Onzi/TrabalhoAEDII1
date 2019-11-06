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
            LinkedList<IndiceHash>[] indiceHash = new LinkedList<IndiceHash>[280];
            
                FazHash.HashArk(indiceHash);
                Console.Clear();
                int dat=1;
            do
            {
                Console.WriteLine("Digite a data:");
                Console.WriteLine("Ou 0 para sair:");
                string num = Console.ReadLine();
                if (Int32.TryParse(num, out dat))
                {
                    dat = Int32.Parse(num);

                    int has = MathB.Hash(MathB.Separator(dat,6));
                    if (indiceHash[has] != null)
                    {
                        using (StreamReader stream = new StreamReader(File.OpenRead(Environment.CurrentDirectory + @"\main.dat")))
                        {
                            foreach (var item in indiceHash[has])
                            {
                                char[] po = new char[1000];
                                stream.BaseStream.Seek(item.pos, SeekOrigin.Begin);
                                
                                stream.Read(po, 0, 620);
                                Console.WriteLine(new string(po)); 
                            }
                        }
                    }
                    
                    
                    
                }



            } while (dat != 0);
            
    
        }
    }
}
