using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Theory
{
    internal class Prim
    {
        GRAPH g=new GRAPH();
        const int INT_MAX=int.MaxValue; 
        public int T = 0;
        List<Tuple<int, int>>[] adj = new List<Tuple<int, int>>[100];
        List<bool> used = new List<bool>();
        public List<Tuple<int, int, int>> mst = new List<Tuple<int, int, int>>();
        public void ReadMatran(GRAPH data)
        {
            this.g = data;
            for (int i = 0; i < g.Dinh; i++)
            {
                adj[i] = new List<Tuple<int, int>>();
                used.Add(false);
            }
            for (int i = 0; i < g.Dinh; i++)
            {
                for(int j = 0; j < g.Dinh; j++)
                {
                    if (g.maTran[i, j] != 0)
                    {
                        adj[i].Add(new Tuple<int, int>(j, g.maTran[i, j]));
                        adj[j].Add(new Tuple<int, int>(i, g.maTran[i,j]));  
                    }
                }
            }
        }
        public void prim(int u)
        {
            used[u] = true;//dua dinh u vào tập V(MST)
            while (mst.Count() < g.Dinh - 1)
            {
                //e=(x,y): cạnh ngắn nhất có x thuộc V và y thuộc V(MST)
                int min_w = INT_MAX;
                int X=-1, Y=-1; //lưu 2 đỉnh của cạnh e
                for(int i = 0; i < g.Dinh; i++)
                {
                    //neu dinh i thuoc tập V(MST)
                    if (used[i])
                    {
                        //duyet danh sach ke cua dinh i
                        foreach(Tuple<int,int> it in adj[i])
                        {
                            int j = it.Item1; int w = it.Item2;
                            if (!used[j] && w<min_w)
                            {
                                min_w = w;
                                X = j;Y = i;
                            }
                        }
                    }
                }
                if (X != -1 && Y != -1)
                {
                    mst.Add(new Tuple<int, int, int>(X, Y, min_w));
                    T += min_w;
                    used[X] = true;
                }
            }

        }
    }
}
