namespace Algorithms.LowLevelSystems.Cache.EvictionPolicies;

/// <summary>
/// Least recently used eviction policy to maintain information about the 
/// least recently used key and evict it the last used key when storage meets
/// the threshold state. 
/// </summary>
public class LruEvictionPolicy<TKey> : IEvictionPolicy<TKey> where TKey: class
{
    private readonly LinkedList<TKey> _accessedQueue;
    private readonly Dictionary<TKey, LinkedListNode<TKey>> _keyToNodeMap;
    public LruEvictionPolicy()
    {
        _accessedQueue = new LinkedList<TKey>();
        _keyToNodeMap = new Dictionary<TKey, LinkedListNode<TKey>>();
    }

    /// <summary>
    /// Updated the last recently used key inside the accessed queue with the current key.
    /// If this is the first time key is being accessed(i.e. inserted inside storage) creates
    /// a fresh entry inside the key to node map. 
    /// </summary>
    /// <param name="key">Key that is either being inserted to or accessed from the storage.</param>
    public void KeyAccessed(TKey key)
    {
        if (_keyToNodeMap.ContainsKey(key))
        {
            _accessedQueue.Remove(_keyToNodeMap[key]);
            _accessedQueue.AddLast(_keyToNodeMap[key]);
        }
        else
        {
            var newNode = new LinkedListNode<TKey>(key);
            _accessedQueue.AddLast(newNode);
            _keyToNodeMap[key] = newNode;
        }
    }

    /// <summary>
    /// Evicts the key which is at the first place inside the accessed queue.
    /// This is the least recently accessed key that needs to be deleted. 
    /// </summary>
    /// <returns>The least recently accessed key removed from the accessed queue.</returns>
    public TKey? EvictKey()
    {
        if (_accessedQueue.Count == 0)
            return null;
        
        var firstKey = _accessedQueue.First();
        _accessedQueue.RemoveFirst();
        
        return firstKey;
        
    }
}