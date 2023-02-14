using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class PoolMono 
{
    
    public GameObject prefab { get; }
    public bool autoExpand { get; set; }
    public Transform container { get; }

    private List<GameObject> pool;

    public PoolMono(GameObject prefab, int count)
    {
        this.prefab = prefab;
        this.container = null;
        
        this.CreatePool(count);
    }

    public PoolMono(GameObject prefab, int count, Transform container)
    {
        this.prefab = prefab;
        this.container = container;
        
        this.CreatePool(count);

    }
    
    public PoolMono(GameObject[] prefabs, int count, Transform container)
    {
        CreatePool();
        this.container = container;
        foreach (GameObject prefab in prefabs)
        {
            //this.prefab = prefab;
            
            for (int i = 0; i < count; i++)
            {
                this.CreateObject(prefab);
            }
        }
        
        
        //this.CreatePool(count);

    }

    private void CreatePool(int count = 0)
    {
        this.pool = new List<GameObject>();

        for (int i = 0; i < count; i++)
        {
            this.CreateObject(prefab);
        }
    }

    private GameObject CreateObject(GameObject prefab, bool isActiveByDefault = false)
    {
        var createdObject = Object.Instantiate(prefab, this.container);
        createdObject.name = prefab.name;
        createdObject.SetActive(isActiveByDefault);
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

    public bool HasFreeElement(string name, out GameObject element)
    {
        foreach (var mono in pool)
        {
            if (mono.name == name)
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

    public GameObject GetFreeElement(GameObject prefab)
    {
        if (this.HasFreeElement(prefab.name, out var element))
        {
            return element; 
        }

        if (this.autoExpand)
        {
            return this.CreateObject(prefab,true);
        }
       
        throw new Exception($"These is no free elements in pool of type {typeof(GameObject)}");
    }

    public void CheckOutFromScreen(float yComparePosition)
    {
        foreach (GameObject elementGameObject in pool)
        {
            if (elementGameObject.activeInHierarchy && elementGameObject.transform.position.y < yComparePosition - ConstantSettings.screenHeightWorld)
            {
                elementGameObject.SetActive(false);
            }
        }
        
    }
}
