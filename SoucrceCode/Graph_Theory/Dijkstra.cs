using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Theory
{
    internal class Dijkstra
    {
        GRAPH g = new GRAPH();
        const int INF = 1_000_000_000; // vô cùng
        public List<int> lstKQ = new List<int>();
        private List<Tuple<int, int>>[] adj = new List<Tuple<int, int>>[100];//mảng 100pt, mỗi pt là 1 lst
        public List<int> dist = new List<int>();
        List<bool> visited = new List<bool>();
        private int[] pre= new int[100];    
        public void ReadMatix(GRAPH data)
        {
            this.g = data;
            for (int i = 0; i < g.Dinh; i++)
            {
                adj[i] = new List<Tuple<int, int>>();
                dist.Add(INF);
                visited.Add(false);
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
                        adj[i].Add(new Tuple<int, int>(j, g.maTran[i,j]));
                        adj[j].Add(new Tuple<int, int>(i, g.maTran[i,j]));
                    }
                }
            }
        }
        public void DijkstraAlgorithm(int start,int end)
        {
            dist[start] = 0;
            pre[start]=start;
            for(int i=0;i<g.Dinh; i++)
            {
                //Tìm đỉnh có khoảng cách nhỏ nhất và chưa được duyệt
                int u = -1;
                int minDist = INF;
                for(int j = 0; j < g.Dinh; j++)
                {
                    if(!visited[i]&& dist[i] < minDist)
                    {
                        u = i;
                        minDist = dist[i];
                    }
                }
                //Đánh dấu đỉnh đã duyệt
                visited[u] = true;
                foreach(Tuple <int,int> it in adj[u])
                {
                    int v = it.Item1;
                    int w = it.Item2;
                    if (dist[v] > dist[u]+w)
                    {
                        dist[v] = dist[u] + w;
                        pre[v] = u; // trước v là u
                    }
                }
            }
            List<int> path = new List<int>();
            int k = end;
            path.Add(k);
            while (k!=start)
            {
                k =pre[k];
                path.Insert(0, k);
            }
            lstKQ = path;
        }
    }
}
