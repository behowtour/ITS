using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsGeneratorPool : MonoBehaviour
{
    [SerializeField] private int poolSize;
    [SerializeField] private bool autoExpand = false;
    [SerializeField] private Anchor[] pointsPrefab;

    private PoolMono<Anchor> pool;
    // Start is called before the first frame update
    void Start()
    {
        this.pool = new PoolMono<Anchor>(pointsPrefab,poolSize,this.transform)
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
