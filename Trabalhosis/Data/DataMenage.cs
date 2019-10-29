using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using xline.IO;


namespace Trabalhosis
{
    public class DataMenage
    {
        public static string ToLen(string fim,int lenght)
        {
            if (fim.Length<lenght)
            {
                fim = fim.PadRight(lenght, ' ');
            }
            else if(fim.Length>lenght)
            {
                
                fim = fim.Substring(0, lenght);
            }
            return fim;
        }
            public static StreamReader Openin()
        {


            try
            {
                string path = Environment.CurrentDirectory + @"\brexit_china.txt";
                StreamReader binary = new StreamReader(path);
                return binary;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;

        }

        public static uint Trata2500(TwitterData[] ohLongJohnson, uint a)
        {
            int b;
            try
            {
                for (b = 0; b < 2500; b++)
                {
                    ohLongJohnson[b].Id = Convert.ToString(a);
                    a++;
                }



                b = 0;


                foreach (TwitterData HashTag in ohLongJohnson)
                {
                    if (HashTag.Mens != null)
                    {
                        MatchCollection mc = Regex.Matches(HashTag.Mens, @"\#\w+\b");
                        string s;
                        if (mc.Count > 0)
                        {
                            string[] fim = new string[mc.Count];
                            for (int i = 0; i < mc.Count; i++)
                            {
                                fim[i] = mc[i].Groups[0].Value;
                            }

                            s = string.Join("", fim);
                            HashTag.HashTag = s;
                        }
                        else
                        {
                            HashTag.HashTag = null;
                        }

                        b++;
                    }

                }
            }
            catch (Exception e)
            {

            }


            return a;
        }

        public static TwitterData[] Traz2500(StreamReader p)
        {

            int cont = 0;
            TwitterData[] essa = new TwitterData[2500];
            string popo;
            string[] aux;

            do
            {


                popo = p.ReadLine();

                aux = popo.Split(';');

                if (aux.Length > 3)
                {
                    TwitterData.PontoEvirgula(aux.Length, aux);
                }

                essa[cont] = new TwitterData(aux, aux.Length, cont);


                cont++;
            } while (!p.EndOfStream && cont < 2500);

            return essa;
        }

        public static void FazTextao(TwitterData[] ohLongJohnson, BinaryWriter binary)
        {
           
            int b = 0;
            string a,g,c,d,f,h,r;
            do
            {

                try
                {
                    
                    a = ohLongJohnson[b].Id.PadRight( 20,' ');

                    
                    if (a.Length!=20)
                    {
                        goto end;
                    }
                     c = ohLongJohnson[b].User.PadRight( 40,' ');
                    if (c.Length!= 40)
                    {
                        goto end;
                    }
                    d = ohLongJohnson[b].Mens.PadRight( 400,' ');
                    if (d.Length != 400)
                    {
                        goto end;
                    }
                    
                    f = ohLongJohnson[b].Geo.PadRight( 40,' ');
                    if (f.Length != 40)
                    {
                        goto end;
                    }
                    g = ohLongJohnson[b].Data.PadRight( 20,' ');
                    if (g.Length != 20)
                    {
                        goto end;
                    }
                    h = ohLongJohnson[b].HashTag.PadRight( 200,' ');
                    if (h.Length!=200)
                    {
                        goto end;
                    }

                    
                    
                        
                        binary.Write(a+";"+c+";"+d+";"+f+";"+g+";"+h+";"+Environment.NewLine);
                        
                        









                }
                catch (Exception)

                {

                }
                
                
                end:
                b++;

            } while (b < 2500 && ohLongJohnson[b] != null);

            


            return;

        }



        public static string TransformaEm(string a, int b)
        {
            while (a.Length != b)
            {
                a.Append(' ');
            }
            return a;


        }

        public static List<long> FazPrim(BinaryWriter binp, List<long> e)
        {
            List<long> ee = new List<long>();
            try
            {
                int a = 0;
                foreach (var item in e)
                {
                    if (a % 3 == 0)
                    {
                        ee.Add(binp.Seek(0, SeekOrigin.Current));
                    }

                    binp.Write(string.Format(($"{(a * 2500).ToString(),15}")));
                    binp.Write(string.Format(($"{item.ToString(),15}")));
                    a++;
                    binp.Write(Environment.NewLine);
                }
            }
            catch (Exception f)
            {

            }
            return ee;
        }
        public static void FazSec(BinaryWriter bins, List<long> e)
        {
            try
            {
                int a = 0;
                foreach (var item in e)
                {
                    bins.Write(string.Format(($"{(a * 6500).ToString(),15}")));
                    bins.Write(string.Format(($"{item.ToString(),15}")));
                    a++;
                    bins.Write(Environment.NewLine);

                }
            }
            catch (Exception f)
            {

            }


        }

        public static void AgoraVai(List<long> e, HashSet<IndiceHash> ind)
        {
            StreamReader stream = new StreamReader(File.OpenRead(Environment.CurrentDirectory + @"\texto.dat"));
            BinaryWriter writer = new BinaryWriter(File.OpenWrite(Environment.CurrentDirectory + @"\main.dat"));

            do
            {
                string all;
                string[] sub;
                all = stream.ReadLine();
                sub = all.Split(';');
                sub[0].Trim();
                sub[0] = Regex.Replace(sub[0], @"[\D]", "");
                ind.Add(new IndiceHash(sub[0], Convert.ToInt32(sub[0])));
                if (Convert.ToInt32(sub[0]) % 2500 == 0)
                {
                    e.Add(writer.Seek(0, SeekOrigin.Current));
                }
                writer.Write(DataMenage.ToLen(sub[0], 20));

                sub[1].Trim();
                sub[1] = Regex.Replace(sub[1], @"[\W]", "");
                writer.Write(DataMenage.ToLen(sub[1], 40));

                sub[2].Trim();
                sub[2] = Regex.Replace(sub[2], @"[^\w]+", "");
                writer.Write(DataMenage.ToLen(sub[2], 400));
                sub[3].Trim();
                sub[3] = Regex.Replace(sub[3], @"[^\w]+", "");
                
                writer.Write(DataMenage.ToLen(sub[3], 40));
                sub[4].Trim();
                sub[4]=sub[4].Substring(0, 10);
                
                 sub[4] = Regex.Replace(sub[4], @"[\D]", @"/");
                writer.Write(DataMenage.ToLen(sub[4],10));
                sub[5].Trim();
                
               
                writer.Write(DataMenage.ToLen(sub[5],20));
                sub[6].Trim();
                
                writer.Write(DataMenage.ToLen(sub[6], 100));

                writer.Write(Environment.NewLine);
                

            } while (!stream.EndOfStream);


            stream.Close();
            writer.Close();


        } 
    }

   
}

        
    


    

