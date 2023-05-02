using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Graph_Theory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GRAPH g = new GRAPH();
            string filePath = "DoThi.txt";
            string[] lines = File.ReadAllLines(filePath);
            g.Dinh = int.Parse(lines[0]);

            for (int i = 1; i <= g.Dinh; i++)
            {
                string[] values = lines[i].Split(' ');
                for (int j = 0; j < g.Dinh; j++)
                {
                    int value = int.Parse(values[j]);
                    g.maTran[i - 1, j] = value;
                }
            }
            int key = 1;
            while (key > 0)
            {
                Console.WriteLine("CAC TINH NANG");
                Console.WriteLine("1. Thuat toan BFS");
                Console.WriteLine("2. Thuat toan DFS");
                Console.WriteLine("3. Thuat toan Dijkstra");
                Console.WriteLine("4. Thuat toan Kruscal");
                Console.WriteLine("5. Thuat toan Prim");
                Console.WriteLine("0. Thoat");
                Console.Write("Ban muon chon tinh nang nao: ");
                key = int.Parse(Console.ReadLine());
                switch (key)
                {
                    case 1:
                        BFS bfs = new BFS();
                        bfs.ReadMatran(g);
                        bfs.AdjacencyList();
                        Console.Write("Nhap dinh: ");
                        int v = int.Parse(Console.ReadLine());
                        bfs.MethodBFS(v);
                        foreach (var i in bfs.lstKQ)
                        {
                            Console.Write("{0} ", i);
                        }
                        Console.WriteLine();
                        break;
                    case 2:
                        DFS dfs = new DFS();
                        dfs.ReadMatran(g);
                        dfs.AdjacencyList();
                        Console.Write("Nhap dinh: ");
                        int h = int.Parse(Console.ReadLine());
                        dfs.MethodDFS(h);
                        foreach (var i in dfs.lstKQ)
                        {
                            Console.Write("{0} ", i);
                        }
                        Console.WriteLine();
                        break;
                    case 3:
                        Dijkstra dij = new Dijkstra();
                        dij.ReadMatix(g);
                        dij.AdjacencyList();
                        int start = int.Parse(Console.ReadLine());
                        int end = int.Parse((Console.ReadLine()));
                        dij.DijkstraAlgorithm(start, end);
                        for (int i = 0; i < dij.lstKQ.Count(); i++)
                        {
                            Console.Write("{0} -->", dij.lstKQ[i]);
                        }
                        Console.WriteLine("\nKhoang cach: {0}", dij.dist[start]);
                        break;
                    case 4:
                        Kruscal k = new Kruscal();
                        k.ReadMatrix(g);
                        k.Kruskal();
                        foreach (var i in k.mst)
                        {
                            Console.WriteLine("{0}{1} w = {2}", i.Item1, i.Item2, i.Item3);
                        }
                        Console.WriteLine("Z = {0}", k.Z);
                        break;
                    case 5:
                        Prim p = new Prim();
                        p.ReadMatran(g);
                        Console.Write("Nhap dinh: ");
                        int u = int.Parse(Console.ReadLine());
                        p.prim(u);
                        foreach (var i in p.mst)
                        {
                            Console.WriteLine("{0}{1} w = {2}", i.Item1, i.Item2, i.Item3);
                        }
                        Console.WriteLine("T = {0}", p.T);
                        break;
                    case 0:
                        break;
                    default:
                        key = 1;
                        break;
                }
            }
        }
    }
}