using System;

class PrimAlgorithm
{
    public static void Prim(int[,] graph, int verticesCount)
    {
        int[] parent = new int[verticesCount];
        int[] key = new int[verticesCount];
        bool[] visited = new bool[verticesCount];

        for (int i = 0; i < verticesCount; ++i)
        {
            key[i] = int.MaxValue;
            visited[i] = false;
        }

        key[0] = 0;
        parent[0] = -1;

        for (int count = 0; count < verticesCount - 1; ++count)
        {
            int u = MinKey(key, visited, verticesCount);
            visited[u] = true;

            for (int v = 0; v < verticesCount; ++v)
            {
                if (Convert.ToBoolean(graph[u, v]) && visited[v] == false && graph[u, v] < key[v])
                {
                    parent[v] = u;
                    key[v] = graph[u, v];
                }
            }
        }

        Print(parent, graph, verticesCount);
    }

    private static int MinKey(int[] key, bool[] set, int verticesCount)
    {
        int min = int.MaxValue, minIndex = 0;

        for (int v = 0; v < verticesCount; ++v)
        {
            if (set[v] == false && key[v] < min)
            {
                min = key[v];
                minIndex = v;
            }
        }

        return minIndex;
    }

    private static void Print(int[] parent, int[,] graph, int verticesCount)
    {
        string[] cities = { "Mersin", "Adana", "Osmaniye", "Hatay", "Maras", "Antalya" };
        Console.WriteLine("Edge \tWeight");
        for (int i = 1; i < verticesCount; ++i)
            Console.WriteLine("{0} - {1}\t{2}", cities[parent[i]], cities[i], graph[i, parent[i]]);
    }

    static void Main(string[] args)
    {
        int[,] graph = {
            {  0, 70,  0,  0,  0,480 },
            { 70,  0, 85,  0,160,  0 },
            {  0, 85,  0, 90,106,  0 },
            {  0,  0, 90,  0,110,  0 },
            {  0,160,106,110,  0,610 },
            {480,  0,  0,  0,610,  0 }
        };

        Prim(graph, 6);
        Console.ReadKey();}
}