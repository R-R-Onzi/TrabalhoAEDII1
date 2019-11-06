using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalhosis
{
    public class ArvoreBin
    {
        NodeArvore raiz = new NodeArvore();
        int quantidade = 0;

        public NodeArvore Root
        {
            get { return raiz; }
        }
        public string Quantidade
        {
            get { return quantidade.ToString(); }
        }

        public void Inserir(string hashtag, long end)
        {
            NodeArvore NewNode = new NodeArvore();
            NewNode.sethashtag(hashtag);
            if (Root.getAnterior == null && raiz.gethashtag == null)
            {
                raiz.sethashtag(hashtag);
                raiz.addList(end);
                raiz.setDireita(null);
                raiz.setEsquerda(null);
            }
            else
            {
                NodeArvore aux = BuscarInsercao(hashtag, end);
                if (aux == null)
                {
                    Console.Beep();
                }
                else
                {
                    if (hashtag.CompareTo(aux.gethashtag) > 0)
                    {
                        aux.setDireita(NewNode);
                        NewNode.setAnterior(aux);
                        quantidade++;
                    }
                    else
                    {
                        aux.setEsquerda(NewNode);
                        NewNode.setAnterior(aux);
                        quantidade++;
                    }
                }
            }
        }

        public NodeArvore BuscarInsercao(string hashtag, long adr)
        {
            NodeArvore node;
            node = Root;
            bool x = true;
            do
            {
                if (hashtag.CompareTo(node.gethashtag) < 0)
                {
                    if (node.getEsquerda == null)
                    {
                        x = false;
                        return node;
                    }
                    if (node.getEsquerda != null)
                    {
                        node = node.getEsquerda;
                    }
                }

                if (hashtag.CompareTo(node.gethashtag) > 0)
                {
                    if (node.getDireita == null)
                    {
                        x = false;
                        return node;
                    }
                    if (node.getDireita != null)
                    {
                        node = node.getDireita;
                    }
                }

                if (hashtag.CompareTo(node.gethashtag) == 0)
                {
                    node.addList(adr);
                    return null;
                }
            } while (x);
            return null;
        }


        public NodeArvore Busca(NodeArvore node, string hashtag)
        {
            if (node == null)
            {
                Console.WriteLine("Não Achei! " + hashtag);
                return null;
            }
            else
            {
                if (hashtag.CompareTo(node.gethashtag) == 0)
                {
                    FileStream binary = new FileStream(Environment.CurrentDirectory + @"\main.dat", FileMode.Open);

                    byte[] mens = new byte[2000];
                    string aux, fim;

                    foreach (var end in node.end_)
                    {
                        binary.Seek(end, SeekOrigin.Begin);
                        binary.Read(mens, 0, 620);
                        aux = new string(Encoding.UTF8.GetChars(mens));
                        fim = aux.Substring(0, 516);
                        Console.WriteLine(fim);
                    }
                    binary.Close();
                }
                else if (hashtag.CompareTo(node.gethashtag) < 0)
                {
                    Busca(node.getEsquerda, hashtag);
                }
                else
                {
                    Busca(node.getDireita, hashtag);
                }
            }
            return null;
        }
    }
}
