using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class PoolMono<T> where T : MonoBehaviour
{
    
    public T prefab { get; }
    public bool autoExpand { get; set; }
    public Transform container { get; }

    private List<T> pool;

    public PoolMono(T prefab, int count)
    {
        this.prefab = prefab;
        this.container = null;
        
        this.CreatePool(count);
    }

    public PoolMono(T prefab, int count, Transform container)
    {
        this.prefab = prefab;
        this.container = container;
        
        this.CreatePool(count);

    }
    
    public PoolMono(T[] prefabs, int count, Transform container)
    {
        CreatePool();
        this.container = container;
        foreach (T prefab in prefabs)
        {
            this.prefab = prefab;
            
            for (int i = 0; i < count; i++)
            {
                this.CreateObject();
            }
        }
        
        
        this.CreatePool(count);

    }

    private void CreatePool(int count = 0)
    {
        this.pool = new List<T>();

        for (int i = 0; i < count; i++)
        {
            this.CreateObject();
        }
    }

    private T CreateObject(bool isActiveByDefault = false)
    {
        var createdObject = Object.Instantiate(this.prefab, this.container);
        createdObject.gameObject.SetActive(isActiveByDefault);
        this.pool.Add(createdObject);
        return createdObject;
    }

    // private T AddObject(T prefab, int count, Transform container, bool isActiveByDefault = false)
    // {
    //    // this.prefab = prefab;
    //     var AddedObject = Object.Instantiate(prefab, this.container);
    //     createdObject.gameObject.SetActive(isActiveByDefault);
    //     this.pool.Add(createdObject);
    //     return createdObject;
    // }

    public bool HasFreeElement(string tag, out T element)
    {
        foreach (var mono in pool)
        {
            if (mono.transform.gameObject.tag == tag)
            {
                if (!mono.gameObject.activeInHierarchy)
                {
                    element = mono;
                    mono.gameObject.SetActive(true);
                    return true;
                }
            }
        }

        element = null;
        return false;
    }

    public T GetFreeElement(T prefab)
    {
        if (this.HasFreeElement(prefab.tag, out var element))
        {
            return element; 
        }

        if (this.autoExpand)
        {
            return this.CreateObject(true);
        }
       
        

        throw new Exception($"These is no free elements in pool of type {typeof(T)}");
    }
}
