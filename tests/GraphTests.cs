using System.Collections.Generic;

namespace tests;

public class GraphTests
{
    [Fact]
    public void BFS_ShouldFindElement()
    {
        Graph graph = new Graph();

        // Add nodes
        graph.AddNode("A");
        graph.AddNode("B");
        graph.AddNode("C");
        graph.AddNode("D");

        // Add edges
        graph.AddEdge("A", "B");
        graph.AddEdge("A", "C");
        graph.AddEdge("B", "D");
        graph.AddEdge("C", "D");

        // Perform BFS and DFS
        List<string> bfsResult = graph.Bfs("A");
        bfsResult.Should().Contain("A");
    }
    [Fact]
    public void DFS_ShouldFindElement()
    {
        Graph graph = new Graph();

        // Add nodes
        graph.AddNode("A");
        graph.AddNode("B");
        graph.AddNode("C");
        graph.AddNode("D");

        // Add edges
        graph.AddEdge("A", "B");
        graph.AddEdge("A", "C");
        graph.AddEdge("B", "D");
        graph.AddEdge("C", "D");

        // Perform BFS and DFS
        List<string> dfsResult = graph.Dfs("A");
        dfsResult.Should().Contain("A");
    }
}