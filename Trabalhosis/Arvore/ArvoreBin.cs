using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalhosis
{
    class ArvoreBin
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
        public void Inserir(int hashtag)
        {
            NodeArvore NewNode = new NodeArvore();
            NewNode.sethashtag(hashtag);
            if (Root.getAnterior == null && raiz.gethashtag == null)
            {
                raiz.sethashtag(hashtag);
                raiz.setDireita(null);
                raiz.setEsquerda(null);
            }
            else
            {
                NodeArvore aux = BuscarInsercao(hashtag);
                if (aux == null)
                {
                    Console.Beep();
                }
                else
                {
                    if (hashtag > aux.gethashtag)
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

        public NodeArvore BuscarInsercao(int hashtag)
        {
            NodeArvore node;
            node = Root;
            bool x = true;
            do
            {
                if (hashtag < node.gethashtag)
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

                if (hashtag > node.gethashtag)
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

                if (hashtag == node.gethashtag)
                {
                    return null;
                }
            } while (x);
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

        public NodeArvore Busca(NodeArvore node, int hashtag)
        {
            if (node == null)
            {
                Console.WriteLine("Não Achei! " + hashtag.ToString());
                return null;
            }
            else
            {
                if (hashtag == node.gethashtag)
                {
                    Console.WriteLine("Achei! " + hashtag.ToString());
                    return node;
                }
                else if (hashtag < node.gethashtag)
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
