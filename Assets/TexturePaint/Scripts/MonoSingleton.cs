using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError(typeof(T).ToString() + "is null");

            return _instance;
        }
    }

    public void Awake()
    {
        // Check if we already have an instance live
        if (_instance != null)
        {
            GameObject.Destroy(this);
            return;
        }

        // If we didn't, then this is it
        _instance = this as T;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }
}
