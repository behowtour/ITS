using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsGenerator : MonoBehaviour
{
    [Header("Static variables")]
    public GameObject[] leafPrefab;
    public int[] pointsRate;
    public bool isDestroyLeaf;
    public Transform backgroundLayerForPoints;

    [Header("Dynamic variables")]
    public GameObject lastLeaf;

    private Camera cam;
    private int numberOfLeaf;
    private int allPartsOfChances;

    void Start()
    {
        numberOfLeaf = 1;
        cam = GetComponent<Camera>();
        allPartsOfChances = 0;
        for (int i = 0; i < pointsRate.Length; i++)
        {
            allPartsOfChances += pointsRate[i];
        }
    }

    public void GenerateFirstPoint()
    {
        GameObject newLeaf;
        newLeaf = Instantiate(leafPrefab[0]);
        newLeaf.transform.position = new Vector3(Random.Range(ConstantSettings.leftBorderWorld, ConstantSettings.rightBorderWorld),0,0);
        newLeaf.name = "Point_" + numberOfLeaf;
        numberOfLeaf++;
        lastLeaf = newLeaf;
    }

    public void GenerateNextPoint()
    {
        if (lastLeaf.transform.position.y < cam.transform.position.y + ConstantSettings.screenHeightWorld / 2)
        {
            int typeOfNextLeaf, nextLeafFinder = 0;
            GameObject newLeaf;
            typeOfNextLeaf = Random.Range(0, allPartsOfChances);
            for (int i = 0; i < pointsRate.Length; i++)
            {
                nextLeafFinder += pointsRate[i];
                if (typeOfNextLeaf<nextLeafFinder)
                {
                    if (leafPrefab[i].CompareTag("RedLeaf") && lastLeaf.CompareTag("RedLeaf"))
                    {
                        GenerateNextPoint();
                        break;
                    }
                    newLeaf = Instantiate(leafPrefab[i]);
                    newLeaf.name = "Point_" + numberOfLeaf;
                    newLeaf.transform.position = new Vector3(Random.Range(ConstantSettings.leftBorderWorld, ConstantSettings.rightBorderWorld), lastLeaf.transform.position.y + Mathf.Max(Random.Range(0, ConstantSettings.screenHeightWorld / 2), ConstantSettings.screenHeightWorld / 10), 0);
                    lastLeaf = newLeaf;
                    numberOfLeaf++;
                    break;
                }
            }
        }
    }

    public void DestroyOldPoint()
    {
        string targetValue = "Point_" + (numberOfLeaf - 10);
        GameObject oldLeaf = GameObject.Find(targetValue);
        if (isDestroyLeaf && oldLeaf)
        {
            Destroy(oldLeaf);
        }
    }
}
