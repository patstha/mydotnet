namespace hellolib;

public class Graph
{
    private readonly Dictionary<string, List<string>> _adjacencyList = new();

    public void AddNode(string node)
    {
        if (!_adjacencyList.ContainsKey(node))
        {
            _adjacencyList[node] = new List<string>();
        }
    }

    public void AddEdge(string from, string to)
    {
        if (_adjacencyList.ContainsKey(from) && _adjacencyList.ContainsKey(to))
        {
            _adjacencyList[from].Add(to);
        }
    }

    public List<string> Bfs(string start)
    {
        if (!_adjacencyList.ContainsKey(start))
        {
            return new List<string>();
        }

        HashSet<string> visited = new();
        Queue<string> queue = new();
        List<string> result = new();

        queue.Enqueue(start);
        visited.Add(start);

        while (queue.Count > 0)
        {
            string node = queue.Dequeue();
            result.Add(node);

            foreach (string neighbor in _adjacencyList[node].Where(neighbor => !visited.Contains(neighbor)))
            {
                queue.Enqueue(neighbor);
                visited.Add(neighbor);
            }
        }

        return result;
    }

    public List<string> Dfs(string start)
    {
        if (!_adjacencyList.ContainsKey(start))
        {
            return new List<string>();
        }

        HashSet<string> visited = new();
        List<string> result = new();
        DfsRecursive(start, visited, result);
        return result;
    }

    private void DfsRecursive(string node, HashSet<string> visited, List<string> result)
    {
        visited.Add(node);
        result.Add(node);

        foreach (string neighbor in _adjacencyList[node].Where(neighbor => !visited.Contains(neighbor)))
        {
            DfsRecursive(neighbor, visited, result);
        }
    }
}