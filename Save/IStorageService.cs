using System;

public interface IStorageService
{
    public void Save(string key, object data, Action<bool> callbackResult = null);
    public void Load<T>(string key, out T data, Action<bool> callbackResult = null);
}