namespace Algorithms.DataStructures.UnionFind;

/// <summary>
/// Quick Find is an eager approach, as we adjust the indexes during the union time.
/// </summary>
public class QuickFindUF
{
    private int[] _vertices;
    
    /// <summary>
    /// Set number of vertices and each vertex is assigned the index.
    /// Takes O(N) time.
    /// </summary>
    /// <param name="numberOfVertices"></param>
    public QuickFindUF(int numberOfVertices)
    {
        _vertices = new int[numberOfVertices];
        for (var index = 0; index < numberOfVertices; index++)
        {
            _vertices[index] = index;
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
        return _vertices[vertex1] == _vertices[vertex2];
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
        if (Connected(vertex1, vertex2))
        {
            return;
        }
        
        var vertex1Index = _vertices[vertex1];
        var vertex2Index = _vertices[vertex2];

        for (int index = 0; index < _vertices.Length; index++)
        {
            if (_vertices[index] == vertex1Index)
            {
                _vertices[index] = vertex2Index;
            }
        }
    }
}