using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected float spawnRate;

    protected float spanwRoll;

    protected bool needSpawn;
    protected bool needCheckRoll;
    protected bool canSpawn = true;

    public abstract bool IsNeedGenerate(float heroSpeed);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
