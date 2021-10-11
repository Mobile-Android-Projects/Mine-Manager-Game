using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T: Component
{
    private static T instance;
    public static T Instance
    {
        get 
        {
            if(instance == null)
            {
                instance = FindObjectOfType<T>();
                if(instance == null)//meaning no such object exists in the scene
                {
                    //create said object
                    GameObject newGO = new GameObject();

                    //make it of type T by adding component of type T
                    instance = newGO.AddComponent<T>();
                }
            }
            
           return instance;
        }
    }

    protected virtual void Awake()
    {
        instance = this as T;
    }
}
