namespace Algorithms.LowLevelSystems.Cache.EvictionPolicies;

/// <summary>
/// Eviction policy interface to evict key and maintain information about latest key accessed.
/// </summary>
public interface IEvictionPolicy<TKey>
{
    void KeyAccessed(TKey key);

    TKey? EvictKey();
}