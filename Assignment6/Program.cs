using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    class Program
    {
        class GFG
        {
            static int V = 8;
            int minDistance(int[] dist,
                            bool[] sptSet)
            {
                int min = int.MaxValue, min_index = -1;

                for (int v = 0; v < V; v++)
                    if (sptSet[v] == false && dist[v] <= min)
                    {
                        min = dist[v];
                        min_index = v;
                    }

                return min_index;
            }

            void printSolution(int[] dist, int n)
            {
                Console.Write("Vertex     Distance "
                              + "from Source\n");
                for (int i = 0; i < V; i++)
                    Console.Write(i + " \t\t " + dist[i] + "\n");

                Console.WriteLine();
                Console.WriteLine("Therefore the shortest distance from vertex 0 (A) to vertex 7 (H) is " + dist[7]);
            }

            void dijkstra(int[,] graph, int src)
            {
                int[] dist = new int[V];

                bool[] sptSet = new bool[V];

                for (int i = 0; i < V; i++)
                {
                    dist[i] = int.MaxValue;
                    sptSet[i] = false;
                }
                dist[src] = 0;

                for (int count = 0; count < V - 1; count++)
                {
                    int u = minDistance(dist, sptSet);

                    sptSet[u] = true;

                    for (int v = 0; v < V; v++)

                        if (!sptSet[v] && graph[u, v] != 0 &&
                            dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
                            dist[v] = dist[u] + graph[u, v];
                }

                // print the constructed distance array 
                printSolution(dist, V);
            }

            public static void Main()
            {
                                            //A, B, C, D, E, F, G, H
                int[,] graph = new int[,] { { 0, 1, 0, 5, 0, 2, 0, 0 }, //A
                                    { 1, 0, 0, 0, 2, 0, 0, 0}, //B
                                    { 0, 0, 0, 0, 4, 0, 0, 1}, //C
                                    { 5, 0, 0, 0, 3, 0, 2, 0 }, //D
                                    { 0, 2, 4, 3, 0, 0, 2, 0 }, //E
                                    { 2, 0, 0, 0, 0, 0, 4, 0 }, //F 
                                    { 0, 0, 0, 2, 2, 4, 0, 5 }, //G
                                    { 0, 0, 1, 0, 0, 0, 5, 0 }, //H
                                    };
                GFG t = new GFG();
                t.dijkstra(graph, 0);

                Console.ReadLine();
            }
        }
    }
}
