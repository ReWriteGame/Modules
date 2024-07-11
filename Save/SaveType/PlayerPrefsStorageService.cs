using System;
using UnityEngine;

public class PlayerPrefsStorageService : IStorageService
{
    public void Save(string key, object data, Action<bool> callbackResult = null)
    {
        string uKey = BuildUniqueKey(key);
        string json = JsonUtility.ToJson(data);

        bool isExists = PlayerPrefs.HasKey(uKey);
        
        PlayerPrefs.SetString(uKey, json);
        callbackResult?.Invoke(true);
    }

    public void Load<T>(string key, out T data, Action<bool> callbackResult = null)
    {
        string uKey = BuildUniqueKey(key);
        string json = PlayerPrefs.GetString(uKey);
        
        bool isExists = PlayerPrefs.HasKey(uKey);
        if (!isExists)
        {
            callbackResult?.Invoke(false);
            data = default;
            return;
        }
        
        data = JsonUtility.FromJson<T>(json);
        callbackResult?.Invoke(data != null);
    }


    private string BuildUniqueKey(string key)
    {
        return  key;
    }
}
