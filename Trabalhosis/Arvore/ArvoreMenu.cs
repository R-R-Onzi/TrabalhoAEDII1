using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Trabalhosis
{
    class ArvoreMenu : IMenuAction
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
                Console.WriteLine("0- Sair ");
                Console.WriteLine("Digite sua opcao: ");
                op = Convert.ToInt32(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        byte[] hashtags = new byte[2000];
                        string aux, fim;

                        long end = 0;
                        int cont = 0;

                        FileStream le = new FileStream(Environment.CurrentDirectory + @"\main.dat", FileMode.Open);
                        do
                        {
                            le.Read(hashtags, 0, 620);
                            aux = new string(Encoding.UTF8.GetChars(hashtags));
                            fim = aux.Substring(517, 100);
                            string[] hashstring = fim.Split('#');
                            fim.Trim();
                            foreach (var item in hashstring)
                            {
                                if (item.Length >= 2)
                                {
                                    tree.Inserir(item, end);
                                }
                            }
                            cont++;
                            end +=620;

                        } while (le.CanRead && cont != 32);
                        le.Close();
                        Console.ReadKey();
                        tree.PrintArvore(tree.Root);
                        break;
                    case 2:
                        Console.WriteLine("Informe a hashtag: ");
                        string hashtag = Console.ReadLine();
                        tree.Busca(tree.Root, hashtag);
                        Console.ReadKey();
                        break;
                }
            } while (op != 0);
        }
    }
}