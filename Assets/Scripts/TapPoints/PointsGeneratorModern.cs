using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsGeneratorModern : MonoBehaviour
{
    [Header("Parameters variables")] 
    [SerializeField] private int poolSize;
    [SerializeField] private bool autoExpand = false;
    [SerializeField] private GameObject[] pointsPrefab;
    [SerializeField] private int[] pointsRate;
    [SerializeField] private Camera cam;
    [SerializeField] private int baseCount;
    
    [Header("Dynamic variables")] 
    public GameObject lastPoint;
    [SerializeField] private int basePointCounter;

    private PoolMono pool;
    private int sumOfRate = 0;

    void Start()
    {
        this.pool = new PoolMono(pointsPrefab, poolSize, this.transform);
        this.pool.autoExpand = this.autoExpand;
        foreach (int rate in pointsRate)
        {
            sumOfRate += rate;
        }

        basePointCounter = 0;
    }

    private void Update()
    {
        pool.CheckOutFromScreen(cam.transform.position.y);
    }

    public void GenerateFirstPoint()
    {
        GameObject newPoint;
        newPoint = pool.GetFreeElement(pointsPrefab[0]);
        newPoint.transform.position =
            new Vector3(Random.Range(ConstantSettings.leftBorderWorld, ConstantSettings.rightBorderWorld), 0, 0);
        //newLeaf.name = "Point_" + numberOfLeaf;
        //numberOfLeaf++;
        lastPoint = newPoint;
        basePointCounter++;
    }

    public void GenerateNextPoint()
    {
        if (lastPoint.transform.position.y < cam.transform.position.y + ConstantSettings.screenHeightWorld)
        {
            if (basePointCounter < baseCount)
            {
                NewPoint(pointsPrefab[0]);
            }
            else
            {
                int typeOfNextPoint, nextPointFinder = 0;
                typeOfNextPoint = Random.Range(0, sumOfRate);
                for (int i = 0; i < pointsRate.Length; i++)
                {
                    nextPointFinder += pointsRate[i];
                    if (typeOfNextPoint < nextPointFinder)
                    {
                        if (pointsPrefab[i].CompareTag("RedLeaf") && lastPoint.CompareTag("RedLeaf"))
                        {
                            typeOfNextPoint = Random.Range(0, sumOfRate);
                            i = 0;
                            break;
                        }
                        NewPoint(pointsPrefab[i]);
                        if (i>2)
                        {
                            basePointCounter = 1;
                        }
                        break;
                    }
                }
            }
            
        }
    }

    private void NewPoint(GameObject prefab)
    {
        GameObject newPoint;
        newPoint = pool.GetFreeElement(prefab);
        //newPoint.name = "Point_" + numberOfLeaf;
        newPoint.name = prefab.name;
        newPoint.transform.position = new Vector3(
            Random.Range(ConstantSettings.leftBorderWorld, ConstantSettings.rightBorderWorld),
            lastPoint.transform.position.y +
            Mathf.Max(Random.Range(0, ConstantSettings.screenHeightWorld / 3),
                ConstantSettings.screenHeightWorld / 10), 0);
        lastPoint = newPoint;
        basePointCounter++;
    }
}
