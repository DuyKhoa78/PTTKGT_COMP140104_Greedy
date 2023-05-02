using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Theory
{
    internal class DFS
    {
        GRAPH g = new GRAPH();
        public List<bool> visited = new List<bool>();
        public List<int> lstKQ=new List<int>();
        public List<int>[] lst = new List<int>[100];
        public void ReadMatran(GRAPH data)
        {
            this.g = data;
            for(int i = 0; i < 100; i++)
            {
                visited.Add(false);
                lst[i] = new List<int>();
            }

        }
        public void AdjacencyList()
        {
            for(int i=0; i < g.Dinh; i++)
            {
                for(int j = 0; j < g.Dinh; j++)
                {
                    if (g.maTran[i, j] != 0)
                    {
                        lst[i].Add(j);
                    }
                }
            }
        }
        public void MethodDFS(int x)
        {
            visited[x]=true;
            lstKQ.Add(x);
            foreach(var item in lst[x]){
                if (!visited[item])
                {
                    MethodDFS(item);
                }
             }
        }
    }
}
