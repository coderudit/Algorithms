namespace Algorithms.DataStructures.UnionFind;

public class UFPathCompression
{
    private readonly int[] _root;
    private readonly int[] _rank;
    public UFPathCompression(int numberOfVertices)
    {
        _root = new int[numberOfVertices];
        _rank = new int[numberOfVertices];
        for (int index = 0; index < numberOfVertices; index++)
        {
            _root[index] = index;
            _rank[index] = 1;
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
        if (vertex == _root[vertex]) {
            return vertex;
        }
        return _root[vertex] = Find(_root[vertex]);
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
        if (_rank[rootOfVertex1] > _rank[rootOfVertex2]) {
            _root[rootOfVertex2] = rootOfVertex1;
        } else if (_rank[rootOfVertex1] < _rank[rootOfVertex2]) {
            _root[rootOfVertex1] = rootOfVertex2;
        } else {
            _root[rootOfVertex2] = rootOfVertex1;
            _rank[rootOfVertex1] += 1;
        }
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