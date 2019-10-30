using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalhosis
{
    public class NodeArvore
    {

        string hashtag;
        LinkedList<long> end = new LinkedList<long>();
        NodeArvore anterior, esquerda, direita;

        public LinkedList<long> end_
        {
            get
            {
                return end;
            }
            set
            {
                end = value;
            }
        }

        public string gethashtag
        {
            get { return hashtag; }
        }

        public NodeArvore getAnterior
        {
            get { return anterior; }
        }

        public NodeArvore getDireita
        {
            get { return direita; }
        }

        public NodeArvore getEsquerda
        {
            get { return esquerda; }
        }

        public void sethashtag(string val)
        {
            hashtag = val;
        }

        public void setAnterior(NodeArvore no)
        {
            anterior = no;
        }

        public void setDireita(NodeArvore no)
        {
            direita = no;
        }

        public void setEsquerda(NodeArvore no)
        {
            esquerda = no;
        }

        public void addList(long adr)
        {
            end.AddLast(adr);
        }
    }
}