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
                    }
                    else
                    {
                        aux.setEsquerda(NewNode);
                        NewNode.setAnterior(aux);
                    }
                }
            }
            quantidade++;
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

                if (hashtag.Equals(node.gethashtag))
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
                if (hashtag.Equals(node.gethashtag))
                {
                    string path = Environment.CurrentDirectory + @"\texto.dat";
                    BinaryReader binary = new BinaryReader(File.OpenRead(path));

                    char[] mens = new char[440];

                    foreach (var end in node.end_)
                    {
                        Int32 pos = Convert.ToInt32(end);
                        binary.Read(mens, pos, 440);
                        Console.WriteLine(mens);
                    }
                }
                else if (hashtag.CompareTo(node.gethashtag) > 0)
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

        public void Imprimir(NodeArvore node)
        {
            Queue<NodeArvore> q = new Queue<NodeArvore>();
            q.Enqueue(node);


            while (q.Count != 0)
            {

                Console.WriteLine((node = q.Dequeue() as NodeArvore).gethashtag);

                if (node.getEsquerda != null)
                {
                    q.Enqueue(node.getEsquerda as NodeArvore);
                }
                if (node.getDireita != null)
                {
                    q.Enqueue(node.getDireita as NodeArvore);
                }
            }
        }
    }
}
