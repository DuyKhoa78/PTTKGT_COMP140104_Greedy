using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Theory
{
    internal class MienLienThong
    {
        GRAPH g = new GRAPH();
        public List<int>[] lstKQ = new List<int>[100];
        List<int>[] lst = new List<int>[100];
        public List<bool> visited = new List<bool>();
        //public int[,] matrix = new int[100, 100];
        public int nLienThong = 0;

        public void ReadMatix(GRAPH data)
        {
            this.g = data;
            for (int i = 0; i < 100; i++)
            {
                lst[i] = new List<int>();
                lstKQ[i] = new List<int>();
                visited.Add(false);
            }
            /*for (int i = 0; i < g.Dinh; i++)
            {
                for (int j = 0; j < g.Dinh; j++)
                {
                    matrix[i, j] = g.maTran[i, j];
                }
            }*/

        }
        public void AdjacencyList()
        {
            for (int i = 0; i < g.Dinh; i++)
            {
                for (int j = 0; j < g.Dinh; j++)
                {
                    if (g.maTran[i, j] != 0)
                    {
                        lst[i].Add(j);
                    }
                }
            }
        }
        public void visit(int x, int nLienThong)
        {
            if (!visited[x])
            {
                visited[x] = true;
                lstKQ[nLienThong].Add(x);
                foreach (int item in lst[x])
                {
                    if (!visited[item])
                    {
                        visit(item, nLienThong);
                    }
                }
            }

        }
        public void ThanhPhanLienThong()
        {
            for (int i = 0; i < g.Dinh; i++)
            {
                if (!visited[i])
                {
                    nLienThong++;
                    visit(i, nLienThong);
                }
            }
        }
        

    }
}
