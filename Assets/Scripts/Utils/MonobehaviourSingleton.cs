using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonobehaviourSingleton<T> : MonoBehaviour where T : MonobehaviourSingleton<T>
{
    private static T instance;
    public bool isPersistant;

    public static T Get()
    {
        return instance;
    }

    public virtual void Awake()
    {

        if (!instance)
        {
            instance = this as T;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        if (isPersistant)
        {
            DontDestroyOnLoad(this);
        }
    }
       
}
