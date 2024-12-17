// See https://aka.ms/new-console-template for more information
using System;
using System.Linq;

class Program
{
    class Edge
    {
        public int u, v, weight;
        public Edge(int u, int v, int weight)
        {
            this.u = u;
            this.v = v;
            this.weight = weight;
        }
    }

    static int[] parent;

    static int Find(int x)
    {
        if (parent[x] != x)
            parent[x] = Find(parent[x]);
        return parent[x];
    }

    static void Union(int x, int y)
    {
        int rootX = Find(x);
        int rootY = Find(y);
        if (rootX != rootY)
            parent[rootX] = rootY;
    }

    static void Kruskal(int n, Edge[] edges)
    {
        parent = new int[n];
        for (int i = 0; i < n; i++) parent[i] = i;

        var sortedEdges = edges.OrderBy(e => e.weight).ToArray();
        int mstWeight = 0;

        foreach (var edge in sortedEdges)
        {
            int u = edge.u, v = edge.v;
            if (Find(u) != Find(v))
            {
                Union(u, v);
                Console.WriteLine($"Edge: ({u}, {v}) with weight {edge.weight}");
                mstWeight += edge.weight;
            }
        }

        Console.WriteLine($"Total MST weight: {mstWeight}");
    }

    static void Main()
    {
        int n = 4;
        Edge[] edges = new Edge[]
        {
            new Edge(0, 1, 10),
            new Edge(0, 2, 6),
            new Edge(0, 3, 5),
            new Edge(1, 3, 15),
            new Edge(2, 3, 4)
        };

        Kruskal(n, edges);
    }
}
