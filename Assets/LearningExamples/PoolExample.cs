using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PoolExample : MonoBehaviour
{

    [SerializeField] private int poolCount = 5;
    [SerializeField] private bool autoExpand = false;
    [SerializeField] private SquareL cubePrefab;

    private PoolMono<SquareL> pool;

    private void Start()
    {
        this.pool = new PoolMono<SquareL>(this.cubePrefab, this.poolCount, this.transform);
        this.pool.autoExpand = this.autoExpand;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.CreateCube();
        }
    }

    private void CreateCube()
    {
        var rX = Random.Range(-5f, 5f);
        var rZ = 0;
        var rY = Random.Range(-5f, 5f);

        var rPosition = new Vector3(rX, rY, rZ);
        var cube = this.pool.GetFreeElement();
        cube.transform.position = rPosition;
    }
}
