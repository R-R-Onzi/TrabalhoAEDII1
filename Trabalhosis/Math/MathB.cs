using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalhosis
{
    class MathB
    {
        public static int Separator(int a,int lenght)
        {
            int aux=0;
            int f;
            int j=1;
            for (int i =0;i<lenght;i++,j*=10)
            {
                f = a % 10;
                a /= 10;
                aux += f * j;
            }



            return aux;
        }
        public static int Hash(int a) 
        {
            int ini = a % 10000;
            a /= 10000;
            ini %= 2000;
            a %= 12;
           
            
            return ini * 12 + a;
        }
    }

    
}
