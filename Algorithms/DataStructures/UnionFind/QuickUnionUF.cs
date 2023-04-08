namespace Algorithms.DataStructures.UnionFind;

/// <summary>
/// Quick Union is a lazy approach, we defer the adjustment of indexes until it is required.
/// </summary>
public class QuickUnionUF
{
    private int[] _vertices;
    public QuickUnionUF(int numberOfVertices)
    {
        _vertices = new int[numberOfVertices];
        for (int index = 0; index < numberOfVertices; index++)
        {
            _vertices[index] = index;
        }
    }

    /// <summary>
    /// Recursively finds the parent of the vertex passed as an argument.
    /// </summary>
    /// <param name="vertex"></param>
    /// <returns></returns>
    private int Root(int vertex)
    {
        while (vertex != _vertices[vertex])
        {
            vertex = _vertices[vertex];
        }

        return vertex;
    }
    
    /// <summary>
    /// Checks if the parent of both vertex 1 and vertex 2 are similar.
    /// If tree is too tall, then searching the root is expensive.
    /// </summary>
    /// <param name="vertex1"></param>
    /// <param name="vertex2"></param>
    /// <returns></returns>
    public bool Connected(int vertex1, int vertex2)
    {
        return Root(vertex1) == Root(vertex2);
    }
    
    /// <summary>
    /// Change the root of vertex 1 to root of vertex 2.
    /// </summary>
    /// <param name="vertex1"></param>
    /// <param name="vertex2"></param>
    public void Union(int vertex1, int vertex2)
    {
        var rootOfVertex1 = Root(vertex1);
        var rootOfVertex2 = Root(vertex2);
        _vertices[rootOfVertex1] = rootOfVertex2;
    }
}