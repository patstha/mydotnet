namespace hellolib;
using System.Collections.Generic;

public class Graph
{
    private Dictionary<string, List<string>> adjacencyList;

    public Graph()
    {
        adjacencyList = new Dictionary<string, List<string>>();
    }

    public void AddNode(string node)
    {
        if (!adjacencyList.ContainsKey(node))
        {
            adjacencyList[node] = new List<string>();
        }
    }

    public void AddEdge(string from, string to)
    {
        if (adjacencyList.ContainsKey(from) && adjacencyList.ContainsKey(to))
        {
            adjacencyList[from].Add(to);
        }
    }

    public List<string> BFS(string start)
    {
        HashSet<string> visited = new HashSet<string>();
        Queue<string> queue = new Queue<string>();
        List<string> result = new List<string>();

        queue.Enqueue(start);
        visited.Add(start);

        while (queue.Count > 0)
        {
            string node = queue.Dequeue();
            result.Add(node);

            foreach (string neighbor in adjacencyList[node])
            {
                if (!visited.Contains(neighbor))
                {
                    queue.Enqueue(neighbor);
                    visited.Add(neighbor);
                }
            }
        }

        return result;
    }

    public List<string> DFS(string start)
    {
        HashSet<string> visited = new HashSet<string>();
        List<string> result = new List<string>();
        DFSRecursive(start, visited, result);
        return result;
    }

    private void DFSRecursive(string node, HashSet<string> visited, List<string> result)
    {
        visited.Add(node);
        result.Add(node);

        foreach (string neighbor in adjacencyList[node])
        {
            if (!visited.Contains(neighbor))
            {
                DFSRecursive(neighbor, visited, result);
            }
        }
    }
}
