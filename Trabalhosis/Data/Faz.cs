using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Trabalhosis
{
    public class Faz : IMenuAction
    {
        public void Run()
        {
            if (File.Exists(Environment.CurrentDirectory+@"\texto.dat"))
            {
                Console.WriteLine("Já existe");
                return;
            }
            
            uint a = 0;
            string path = Environment.CurrentDirectory + @"\texto.dat";
            
            BinaryWriter binary = new BinaryWriter(File.Open(path, FileMode.Append));
            StreamReader p = DataMenage.Openin();
            

            do
                {
                    
                TwitterData[] main = DataMenage.Traz2500(p);
                a = DataMenage.Trata2500(main,a);
                
                DataMenage.FazTextao(main,binary);
                
                } while (a % 2500 == 0);
            binary.Close();
            p.Close();
            
          

        }
        


    }
}
