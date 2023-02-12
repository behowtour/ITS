using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsGeneratorPool : MonoBehaviour
{
    [SerializeField] private int poolSize;
    [SerializeField] private bool autoExpand = false;
    [SerializeField] private Anchor[] pointsPrefab;
    [SerializeField] private int[] pointsRate;
    [SerializeField] private Camera cam;
    
    [Header("Dynamic variables")]
    public Anchor lastPoint;

    private PoolMono<Anchor> pool;
    private int sumOfRate = 0;
    
    void Start()
    {
        this.pool = new PoolMono<Anchor>(pointsPrefab, poolSize, this.transform);
        this.pool.autoExpand = this.autoExpand;
        foreach (int rate in pointsRate)
        {
            sumOfRate += rate;
        }
    }
    
    public void GenerateFirstPoint()
    {
        Anchor newPoint;
        newPoint = pool.GetFreeElement(pointsPrefab[0]);
        newPoint.transform.position = new Vector3(Random.Range(ConstantSettings.leftBorderWorld, ConstantSettings.rightBorderWorld),0,0);
        //newLeaf.name = "Point_" + numberOfLeaf;
        //numberOfLeaf++;
        lastPoint = newPoint;
    }

    public void GenerateNextPoint()
    {
        if (lastPoint.transform.position.y < cam.transform.position.y + ConstantSettings.screenHeightWorld / 2)
        {
            int typeOfNextPoint, nextPointFinder = 0;
            Anchor newPoint;
            typeOfNextPoint = Random.Range(0, sumOfRate);
            for (int i = 0; i < pointsRate.Length; i++)
            {
                nextPointFinder += pointsRate[i];
                if (typeOfNextPoint<nextPointFinder)
                {
                    if (pointsPrefab[i].CompareTag("RedLeaf") && lastPoint.CompareTag("RedLeaf"))
                    {
                        GenerateNextPoint();
                        break;
                    }
                    newPoint = pool.GetFreeElement(pointsPrefab[i]);
                    //newPoint.name = "Point_" + numberOfLeaf;
                    newPoint.transform.position = new Vector3(Random.Range(ConstantSettings.leftBorderWorld, ConstantSettings.rightBorderWorld), lastPoint.transform.position.y + Mathf.Max(Random.Range(0, ConstantSettings.screenHeightWorld / 2), ConstantSettings.screenHeightWorld / 10), 0);
                    lastPoint = newPoint;
                    break;
                }
            }
        }
    }

}
