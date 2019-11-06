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
                Console.WriteLine("3- Escrever arvore.");
                Console.WriteLine("0- Sair ");
                Console.WriteLine("Digite sua opcao: ");
                op = Convert.ToInt32(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        byte[] hashtags = new byte[2000];
                        string aux, fim;

                        long end = 0;
                        int count=0;
                        FileStream le = new FileStream(Environment.CurrentDirectory + @"\main.dat", FileMode.Open);
                        do
                        {

                            le.Read(hashtags, 0, 620);
                            aux = new string(Encoding.UTF8.GetChars(hashtags));
                            fim = aux.Substring(517, 100);
                            string[] hashstring = fim.Split('#');
                            foreach (var item in hashstring)
                            {
                                tree.Inserir(item, end);
                            }

                            end += 620;
                            count ++;
                        } while (le.CanRead&& count !=10);
                        le.Close();
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