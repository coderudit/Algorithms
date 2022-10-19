using Algorithms.LowLevelSystems.Cache.Exceptions;

namespace Algorithms.LowLevelSystems.Cache.Storage;

public class DictionaryStorage<TKey, TValue>: IStorage<TKey, TValue> where TKey: notnull where TValue: class
{
    private readonly int _storageSize;
    private readonly Dictionary<TKey, TValue> _storageMap = new();

    public DictionaryStorage(int capacity)
    {
        _storageSize = capacity;
    }
    
    public void Add(TKey key, TValue value)
    {
        if (IsStorageFull())
        {
            throw new StorageFullException("Storage capacity reached.");
        }
        _storageMap.Add(key, value);
    }

    public TValue Get(TKey key)
    {
        if(!_storageMap.ContainsKey(key))
            throw new StorageKeyNotFoundException(key + " does not exist in the cache.");
        
        return _storageMap[key];
    }

    public bool Remove(TKey key)
    {
        if(!_storageMap.ContainsKey(key))
            throw new StorageKeyNotFoundException(key + " does not exist in the cache.");

        return _storageMap.Remove(key);
    }

    private bool IsStorageFull()
    {
        return _storageMap.Count == _storageSize;
    }
}