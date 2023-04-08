namespace Algorithms.DataStructures.UnionFind;

/// <summary>
/// Quick Find is an eager approach, as we adjust the indexes during the union time.
/// </summary>
public class QuickFindUF
{
    private readonly int[] _root;
    
    /// <summary>
    /// Set number of vertices and each vertex is assigned the index.
    /// Takes O(N) time.
    /// </summary>
    /// <param name="numberOfVertices"></param>
    public QuickFindUF(int numberOfVertices)
    {
        _root = new int[numberOfVertices];
        for (var index = 0; index < numberOfVertices; index++)
        {
            _root[index] = index;
        }
    }
    
    public int Find(int vertex) {
        return _root[vertex];
    }

    /// <summary>
    /// Finds the parent of both the vertices, and makes the parent of both the vertices same.
    /// Max number of array access is 2N+2. For N union commands there are N*N array access.
    /// Therefore, quadratic time access. This makes Union operation too slow.
    /// </summary>
    /// <param name="vertex1"></param>
    /// <param name="vertex2"></param>
    public void Union(int vertex1, int vertex2)
    {
        var rootOfVertex1 = Find(vertex1);
        var rootOfVertex2 = Find(vertex2);
        
        //These vertices are already connected.s
        if (rootOfVertex1 == rootOfVertex2)
        {
            return;
        }
        
        for (int index = 0; index < _root.Length; index++)
        {
            //All of the vertices that have root as root of vertex 2, change them to root of vertex 1.
            if (_root[index] == rootOfVertex2)
            {
                _root[index] = rootOfVertex1;
            }
        }
    }
    
    /// <summary>
    /// Check whether vertex 1 an vertex 2 are in the same component.
    /// Number of array access is 2. Takes O(1).
    /// </summary>
    /// <param name="vertex1"></param>
    /// <param name="vertex2"></param>
    /// <returns></returns>
    public bool Connected(int vertex1, int vertex2)
    {
        return Find(vertex1) == Find(vertex2);
    }
}