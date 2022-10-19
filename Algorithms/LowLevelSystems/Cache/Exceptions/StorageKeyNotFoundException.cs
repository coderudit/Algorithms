namespace Algorithms.LowLevelSystems.Cache.Exceptions;

public class StorageKeyNotFoundException: Exception
{
    public StorageKeyNotFoundException(string message):
        base(string.Format("Key not found exception: " + message))
    {
        
    }
}