using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Trabalhosis
{
    public class Destroy : IMenuAction
    {
        public void Run()
        {
            if (File.Exists(Environment.CurrentDirectory+ @"\main.dat"))
            {
                File.Delete(Environment.CurrentDirectory+@"\main.dat");
                File.Delete(Environment.CurrentDirectory+@"\Sec.dat");
                File.Delete(Environment.CurrentDirectory+@"\Prim.dat");
                File.Delete(Environment.CurrentDirectory + @"\Dic1.dat");
            }
           
        }
    }
}
