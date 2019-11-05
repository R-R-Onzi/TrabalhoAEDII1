using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Trabalhosis.Data
{
    class Thesis : IMenuAction
    {
        public void Run()
        {
            int b=0, B=0;
            using (StreamReader le = new StreamReader(File.OpenRead(Environment.CurrentDirectory + @"\main.dat")))
            {
                do
                {
                    char[] po = new char[1000];
                    

                    le.Read(po, 0, 620);
                    
                    string a = new string(po);
                   
                    a = a.Substring(64,400);
                    a.TrimEnd();
                    MatchCollection mc = Regex.Matches(a, @"\b\w+Brexit\w");
                    B += mc.Count;
                    mc = Regex.Matches(a, @"\b\w+brexit\w");
                    b += mc.Count;
                } while (!le.EndOfStream);
            }
            Console.WriteLine("Foram no Total {0} Brexit's e {1} brexit's.",B,b);
            Console.ReadKey();
        }
    }
}
