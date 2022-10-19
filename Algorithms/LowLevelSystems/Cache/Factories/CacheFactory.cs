using Algorithms.LowLevelSystems.Cache.EvictionPolicies;
using Algorithms.LowLevelSystems.Cache.Storage;

namespace Algorithms.LowLevelSystems.Cache.Factories;

public class CacheFactory<TKey, TValue> where TKey: class where TValue: class
{
    public Cache<TKey, TValue> DefaultCache()
    {
        return new Cache<TKey, TValue>(new DictionaryStorage<TKey, TValue>(10), new LruEvictionPolicy<TKey>());
    }
}