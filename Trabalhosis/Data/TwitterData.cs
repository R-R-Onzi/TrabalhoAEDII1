using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalhosis
{
    public class TwitterData
    {
        

        public string Id { get; set; }

        public string User { get; set; }

        public string Mens { get; set; }

        public string Data { get; set; }

        public string Geo { get; set; }

        public string HashTag { get; set; }


        public TwitterData(string[] polpo, int a, int al)
        {


            this.User = Encoding.UTF8.GetString(Encoding.Convert(Encoding.Unicode,Encoding.UTF8,Encoding.Unicode.GetBytes(polpo[0])));

            if (a < 2)
            {
                this.Mens = null;
            }
            else
            {
                this.Mens = Encoding.UTF8.GetString(Encoding.Convert(Encoding.Unicode, Encoding.UTF8, (Encoding.Unicode.GetBytes(polpo[1]))));
            }
            if (a < 3)
            {
                this.Geo = null;
            }
            else
            {
                this.Geo = Encoding.UTF8.GetString((Encoding.Convert(Encoding.Unicode, Encoding.UTF8, Encoding.Unicode.GetBytes(polpo[2]))));
            }
            if (a < 4)
            {

                this.Data = Encoding.UTF8.GetString((Encoding.UTF8.GetBytes(string.Format($"{Ale.RandomDay(Environment.TickCount, al),10}"))));
            }
            else
            {
                this.Data = Encoding.UTF8.GetString((Encoding.Convert(Encoding.Unicode, Encoding.UTF8, Encoding.Unicode.GetBytes(polpo[3]))));
            }
            if (a < 5)
            {
                this.HashTag = null;
            }
            else
            {
                this.HashTag = Encoding.UTF8.GetString((Encoding.Convert(Encoding.Unicode, Encoding.UTF8, Encoding.Unicode.GetBytes(polpo[4])))); 
            }
           
        }


        public static void PontoEvirgula(int quant, string[] txt)
        {
            for (int i = 2; i != (quant); i++)
            {
                txt[1] = string.Concat(txt[1], txt[i]);
            }
            txt[2] = string.Copy(txt[quant - 1]);
        }
    }
}
