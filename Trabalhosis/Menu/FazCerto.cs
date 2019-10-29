using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalhosis.Menu
{
    class FazCerto : IMenuAction
    {
        public void Run()
        {
            HashSet<IndiceHash> ind = new HashSet<IndiceHash>();
            string path1 = Environment.CurrentDirectory + @"\Sec.dat";
            string path2 = Environment.CurrentDirectory + @"\Prim.dat";
            List<long> e = new List<long>();
            List<long> ee = new List<long>();
            DataMenage.AgoraVai(e,ind);


            BinaryWriter binp = new BinaryWriter(File.Open(path1, FileMode.Append));

            ee = DataMenage.FazPrim(binp, e);
            binp.Close();

            BinaryWriter bins = new BinaryWriter(File.Open(path2, FileMode.Append));
            DataMenage.FazSec(bins, ee);
            bins.Close();

        }
    }
}
