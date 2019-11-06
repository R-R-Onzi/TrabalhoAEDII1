using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Trabalhosis
{
    class Print : IMenuAction
    {
        public void Run()
        {
            BinaryReader reader = new BinaryReader(File.OpenRead(Environment.CurrentDirectory + @"\Main.dat"));
            try
            {
                do
                {
                    Console.WriteLine(reader.ReadString());
                    
                } while (true);
            }
            catch(Exception e)
            {

            }
            reader.Close();
            
        }
    }
}
