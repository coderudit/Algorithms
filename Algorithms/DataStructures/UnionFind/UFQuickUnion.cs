namespace Algorithms.DataStructures.UnionFind;

/// <summary>
/// Union Find aka Disjoint Set
/// Quick Union is a lazy approach, we defer the adjustment of indexes until it is required.
/// </summary>
public class QuickUnionUF
{
    private readonly int[] _root;
    public QuickUnionUF(int numberOfVertices)
    {
        _root = new int[numberOfVertices];
        for (int index = 0; index < numberOfVertices; index++)
        {
            _root[index] = index;
        }
    }

    /// <summary>
    /// Recursively finds the parent of the vertex passed as an argument.
    /// Results in the worst-case scenario for the find function if a tree is form with long chain.
    /// </summary>
    /// <param name="vertex"></param>
    /// <returns></returns>
    private int Find(int vertex)
    {
        while (vertex != _root[vertex])
        {
            vertex = _root[vertex];
        }

        return vertex;
    }

    /// <summary>
    /// Change the root of vertex 1 to root of vertex 2.
    /// </summary>
    /// <param name="vertex1"></param>
    /// <param name="vertex2"></param>
    public void Union(int vertex1, int vertex2)
    {
        var rootOfVertex1 = Find(vertex1);
        var rootOfVertex2 = Find(vertex2);
        if (rootOfVertex1 == rootOfVertex2)
            return;
        _root[rootOfVertex1] = rootOfVertex2;
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
        return Find(vertex1) == Find(vertex2);
    }
}