using Algorithms.LowLevelSystems.Cache.EvictionPolicies;
using Algorithms.LowLevelSystems.Cache.Exceptions;
using Algorithms.LowLevelSystems.Cache.Storage;

namespace Algorithms.LowLevelSystems.Cache;

public class Cache<TKey, TValue> where TValue: class
{
    
    private readonly IStorage<TKey, TValue> _storage;
    private readonly IEvictionPolicy<TKey> _evictionPolicy;
    
    public Cache(IStorage<TKey, TValue> storage, IEvictionPolicy<TKey> evictionPolicy)
    {
        _storage = storage;
        _evictionPolicy = evictionPolicy;
    }

    public void Add(TKey key, TValue value)
    {
        try
        {
            _storage.Add(key, value);
            _evictionPolicy.KeyAccessed(key);
        }
        catch (StorageFullException exception)
        {
            Console.WriteLine(exception + " Trying to evict key. ");
            var evictedKey = _evictionPolicy.EvictKey();
            if (evictedKey == null)
                throw new InvalidOperationException("Unable to evict key.");
            _storage.Remove(evictedKey);
            Add(key, value);
        }
        
        _evictionPolicy.KeyAccessed(key);
    }

    public TValue? Get(TKey key)
    {
        try
        {
            var value = _storage.Get(key);
            _evictionPolicy.KeyAccessed(key);
            return value;
        }
        catch (StorageKeyNotFoundException exception)
        {
            Console.WriteLine(exception + " Trying to access " +  key + " not possible. ");
            return null;
        }
    }
}