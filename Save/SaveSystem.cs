using System;

public static class SaveSystem
{
    private static IStorageService storageService;

    static SaveSystem() => storageService = new PlayerPrefsStorageService();
    
    public static void Save(string key, object data, Action<bool> callbackResult = null) =>
        storageService.Save(key, data, callbackResult);
    
    public static void Load<T>(string key, out T data, Action<bool> callbackResult = null) =>
        storageService.Load(key, out data, callbackResult);
}
// this instance to save data

//todo: make logic if we want to store different data in different places
//for example, graphics locally and characters in the cloud