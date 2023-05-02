using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Theory
{
    internal class BFS
    {
        GRAPH g = new GRAPH();
        public List<bool> visited = new List<bool>();
        public List<int> lstKQ = new List<int>();
        public List<int>[] lst = new List<int>[100];
        Queue<int> que = new Queue<int>();
        public void ReadMatran(GRAPH data)
        {
            this.g = data;
            for (int i = 0; i < 100; i++)
            {
                visited.Add(false);
                lst[i] = new List<int>();
            }

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
        public void MethodBFS(int x)
        {
            que.Enqueue(x);
            visited[x] = true;
            while(que.Count != 0)
            {
                int v = que.Dequeue();
                lstKQ.Add(v);
                foreach(var item in lst[v])
                {
                    if (!visited[item])
                    {
                        que.Enqueue(item);
                        visited[item] = true;
                    }
                }
            }
        }
    }
}
