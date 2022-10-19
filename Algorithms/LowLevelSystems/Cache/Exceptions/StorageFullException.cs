namespace Algorithms.LowLevelSystems.Cache.Exceptions;

public class StorageFullException : Exception
{
    public StorageFullException(string message):
        base(String.Format("Storage full exception: " + message))
    {
            
    }
}