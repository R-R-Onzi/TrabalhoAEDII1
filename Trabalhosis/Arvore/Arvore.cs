using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Trabalhosis
{
    class Arvore : IMenuAction
    {
        public void Run()
        {
            ArvoreBin tree = new ArvoreBin();
            int op = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("------------------MENU--------------------\n");
                Console.WriteLine("1- Criar arvore.");
                Console.WriteLine("2- Buscar.");
                Console.WriteLine("3- Escrever arvore.");
                Console.WriteLine("0- Sair ");
                Console.WriteLine("Digite sua opcao: ");
                op = Convert.ToInt32(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        string path = Environment.CurrentDirectory + @"\main.dat";
                        byte[] hashtags = new byte[2000];
                        string aux;

                        int end = 517;

                        BinaryReader binary = new BinaryReader(File.OpenRead(path));

                        do
                        {
                            binary.Read(hashtags, end, 100);
                            aux = new string(Encoding.UTF8.GetChars(hashtags));
                            string[] hashstring = aux.Split('#');
                            foreach (var hash in hashstring)
                            {
                                tree.Inserir(hash, end);
                                end += 641;
                            }
                        } while (binary.BaseStream.Position != binary.BaseStream.Length);
                        binary.Close();
                        break;
                    case 2:
                        Console.WriteLine("Informe a hashtag: ");
                        string hashtag = Console.ReadLine();
                        tree.Busca(tree.Root, hashtag);
                        break;
                    case 3:
                        tree.Imprimir(tree.Root);
                        break;
                }
            } while (op != 0);
        }
    }
}
