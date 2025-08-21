using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayCaster
{
    internal class Mapa
    {

        public int ALTURA, LARGURA, TAMANHO;
        public int[] Grid { get; set; }

        public Mapa(int a, int l, int t)
        {
            ALTURA = a;
            LARGURA = l;
            TAMANHO = t;

            Grid = new int[ALTURA * LARGURA];
        }

    }
}
