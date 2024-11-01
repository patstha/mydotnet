namespace tests;

public class GraphTests
{
    [Fact]
    public void Freebie()
    {
        Assert.True(true);
    }

    [Fact]
    public void AddNode_ShouldAddNode()
    {
        // Arrange
        Graph graph = new();

        // Act
        graph.AddNode("A");

        // Assert
        graph.Bfs("A").Should().Contain("A");
    }

    [Fact]
    public void AddEdge_ShouldAddEdge()
    {
        // Arrange
        Graph graph = new();
        graph.AddNode("A");
        graph.AddNode("B");

        // Act
        graph.AddEdge("A", "B");

        // Assert
        graph.Bfs("A").Should().Contain("B");
    }

    [Fact]
    public void AddEdge_ShouldNotAddEdgeIfNodesDoNotExist()
    {
        // Arrange
        Graph graph = new();

        // Act
        graph.AddEdge("A", "B");

        // Assert
        graph.Bfs("A").Should().BeEmpty();
    }

    [Fact]
    public void AddEdge_ShouldNotAddEdgeIfOnlyFromNodeExists()
    {
        // Arrange
        Graph graph = new();
        graph.AddNode("A");

        // Act
        graph.AddEdge("A", "B");

        // Assert
        graph.Bfs("A").Should().NotContain("B");
    }

    [Fact]
    public void AddEdge_ShouldNotAddEdgeIfOnlyToNodeExists()
    {
        // Arrange
        Graph graph = new();
        graph.AddNode("B");

        // Act
        graph.AddEdge("A", "B");

        // Assert
        graph.Bfs("B").Should().NotContain("A");
    }

    [Fact]
    public void BFS_ShouldFindElement()
    {
        // Arrange
        Graph graph = new();
        graph.AddNode("A");
        graph.AddNode("B");
        graph.AddNode("C");
        graph.AddNode("D");
        graph.AddEdge("A", "B");
        graph.AddEdge("A", "C");
        graph.AddEdge("B", "D");
        graph.AddEdge("C", "D");

        // Act
        List<string> bfsResult = graph.Bfs("A");

        // Assert
        bfsResult.Should().ContainInOrder("A", "B", "C", "D");
    }

    [Fact]
    public void DFS_ShouldFindElement()
    {
        // Arrange
        Graph graph = new();
        graph.AddNode("A");
        graph.AddNode("B");
        graph.AddNode("C");
        graph.AddNode("D");
        graph.AddEdge("A", "B");
        graph.AddEdge("A", "C");
        graph.AddEdge("B", "D");
        graph.AddEdge("C", "D");

        // Act
        List<string> dfsResult = graph.Dfs("A");

        // Assert
        dfsResult.Should().ContainInOrder("A", "B", "D", "C");
    }

    [Fact]
    public void BFS_ShouldHandleDisconnectedGraph()
    {
        // Arrange
        Graph graph = new();
        graph.AddNode("A");
        graph.AddNode("B");
        graph.AddNode("C");
        graph.AddNode("D");
        graph.AddEdge("A", "B");
        graph.AddEdge("C", "D");

        // Act
        List<string> bfsResult = graph.Bfs("A");

        // Assert
        bfsResult.Should().ContainInOrder("A", "B");
        bfsResult.Should().NotContain("C");
        bfsResult.Should().NotContain("D");
    }

    [Fact]
    public void DFS_ShouldHandleDisconnectedGraph()
    {
        // Arrange
        Graph graph = new();
        graph.AddNode("A");
        graph.AddNode("B");
        graph.AddNode("C");
        graph.AddNode("D");
        graph.AddEdge("A", "B");
        graph.AddEdge("C", "D");

        // Act
        List<string> dfsResult = graph.Dfs("A");

        // Assert
        dfsResult.Should().ContainInOrder("A", "B");
        dfsResult.Should().NotContain("C");
        dfsResult.Should().NotContain("D");
    }

    [Fact]
    public void BFS_ShouldHandleCycles()
    {
        // Arrange
        Graph graph = new();
        graph.AddNode("A");
        graph.AddNode("B");
        graph.AddNode("C");
        graph.AddEdge("A", "B");
        graph.AddEdge("B", "C");
        graph.AddEdge("C", "A");

        // Act
        List<string> bfsResult = graph.Bfs("A");

        // Assert
        bfsResult.Should().ContainInOrder("A", "B", "C");
    }

    [Fact]
    public void DFS_ShouldHandleCycles()
    {
        // Arrange
        Graph graph = new();
        graph.AddNode("A");
        graph.AddNode("B");
        graph.AddNode("C");
        graph.AddEdge("A", "B");
        graph.AddEdge("B", "C");
        graph.AddEdge("C", "A");

        // Act
        List<string> dfsResult = graph.Dfs("A");

        // Assert
        dfsResult.Should().ContainInOrder("A", "B", "C");
    }

    [Fact]
    public void BFS_ShouldReturnEmptyListForNonExistentStartNode()
    {
        // Arrange
        Graph graph = new();
        graph.AddNode("A");
        graph.AddNode("B");

        // Act
        List<string> bfsResult = graph.Bfs("C");

        // Assert
        bfsResult.Should().BeEmpty();
    }

    [Fact]
    public void DFS_ShouldReturnEmptyListForNonExistentStartNode()
    {
        // Arrange
        Graph graph = new();
        graph.AddNode("A");
        graph.AddNode("B");

        // Act
        List<string> dfsResult = graph.Dfs("C");

        // Assert
        dfsResult.Should().BeEmpty();
    }
}