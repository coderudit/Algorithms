namespace Algorithms.LowLevelSystems.Cache.Storage;

public interface IStorage<TKey, TValue>
{
    void Add(TKey key, TValue value);

    TValue Get(TKey key);

    bool Remove(TKey key);
}