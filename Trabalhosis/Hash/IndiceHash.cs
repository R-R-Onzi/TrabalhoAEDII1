﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Trabalhosis
{

    public class IndiceHash
    {
        public int Data { get; set; }

        public long pos { get; set; }

        
        public IndiceHash(string b,int a)
        {
            this.Data = Convert.ToInt32(b);
            this.pos = a;
        }

        public IndiceHash(int b, long a)
        {
            this.Data = b;
            this.pos = a;
        }

        public static void SerializeNow(HashSet<IndiceHash> c)
        {
            

            Stream s = File.Open(Environment.CurrentDirectory + @"\temp.dat", FileMode.Create);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(s, c);
            s.Close();
        }
        public static HashSet<IndiceHash> DeSerializeNow()
        {
            HashSet<IndiceHash> c = new HashSet<IndiceHash>();
            Stream s = File.Open(Environment.CurrentDirectory + @"\temp.dat", FileMode.Create);
            BinaryFormatter b = new BinaryFormatter();
            c = (HashSet<IndiceHash>)b.Deserialize(s);
            s.Close();
            return c;
        }

    }
}
