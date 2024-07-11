using System;
using System.IO;
using UnityEngine;

//using Newtonsoft.Json;

public class JsonToFileStorageService : IStorageService
{
    public void Save(string key, object data, Action<bool> callbackResult = null)
    {
        string path = BuildPath(key);
        string json = JsonUtility.ToJson(data);
        // string json = JsonConvert.SerializeObject(data);// little better

        bool isExists = File.Exists(path);
        using (var fileStream = new StreamWriter(path))
        {
            fileStream.Write(json);
        }

        callbackResult?.Invoke(true); // write better
    }

    public void Load<T>(string key, out T data, Action<bool> callbackResult = null)
    {
        string path = BuildPath(key);

        bool isExists = File.Exists(path);
        if (!isExists)
        {
            callbackResult?.Invoke(false);
            data = default;
            return;
        }
        
        using (var fileStream = new StreamReader(path))
        {
            var json = fileStream.ReadToEnd();
            data = JsonUtility.FromJson<T>(json);
        }

        callbackResult?.Invoke(data != null);
    }

    private string BuildPath(string key) => Path.Combine(Application.persistentDataPath, key);
}