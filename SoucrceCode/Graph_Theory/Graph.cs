using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Theory
{
    internal class GRAPH
    {
        private int vertices;
        private int[,] matrix = new int[1000, 1000];
        public int Dinh
        {
            get { return vertices; }
            set { vertices = value; }
        }
        public int[,] maTran
        {
            get { return matrix; }
            set { matrix = value; }
        }
    }
}
