using System.ComponentModel.Design;

namespace test1
{
    class Graph
    {
        int[,] adj = new int[6, 6]
        {
            {0,1,0,1,0,0 },
            {1,0,1,1,0,0 },
            {0,1,0,0,0,0 },
            {1,1,0,0,0,0 },
            {0,0,0,0,0,1 },
            {0,0,0,0,1,0 },
        };

        List<int>[] adj2 = new List<int>[]
        {
            new List<int>() { 1, 3 },
            new List<int>() { 0, 2, 3 },
            new List<int>() { 1 },
            new List<int>() { 0, 1, 4 },
            new List<int>() { 3 ,5 },
            new List<int>() { 4 }
        };

        bool[] visited = new bool[6];

        public void DFS(int now)
        {
            Console.WriteLine(now);
             visited[now] = true;

            for(int next = 0; next<6;next++)
            {
                if (adj[now,next] ==0)
                    continue;
                if (visited[next])
                    continue;
                DFS(next);
            }
        }

        public void DFS2(int now)
        {
            Console.WriteLine(now);
            visited[now] = true;

            foreach(int next in adj2[now])
            {
                if (visited[next])
                    continue;
                DFS2 (next);
            }
        }

        public void SearchAll()
        {
            visited = new bool[6];
            for (int now = 0; now < 6; now++)
                if (visited[now] == false)
                    DFS(now);
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            graph.SearchAll();
        }
    }
}
