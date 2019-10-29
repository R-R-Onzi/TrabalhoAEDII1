using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalhosis
{
    class NodeArvore
    {
        int hashtag;
        NodeArvore anterior, esquerda, direita;

        public int gethashtag
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

        public void sethashtag(int val)
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
    }
}
