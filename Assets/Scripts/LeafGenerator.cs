using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafGenerator : MonoBehaviour
{
    [Header("Static variables")]
    public GameObject[] leafPrefab;
    public int[] pointsRate;
    public int greenLeafChance, orangeLeafChance;
    public bool isDestroyLeaf;

    [Header("Dynamic variables")]
    public GameObject lastLeaf;
    public int redLeafChance;
    public float leftBorderWorld, rightBorderWorld, screenHeightWorld;

    private Camera cam;
    private int numberOfLeaf;
    private int allPartsOfChances;

    void Start()
    {
        numberOfLeaf = 1;
        redLeafChance = 100000 - greenLeafChance - orangeLeafChance;
        cam = GetComponent<Camera>();
        allPartsOfChances = 0;
        for (int i = 0; i < pointsRate.Length; i++)
        {
            allPartsOfChances += pointsRate[i];
        }
    }

    public void GenerateNextPointLegacy()
    {
        if (lastLeaf.transform.position.y < cam.transform.position.y + screenHeightWorld / 2)
        {
            int typeOfNextLeaf;
            GameObject newLeaf;
            if (lastLeaf.tag.Contains("RedLeaf"))
            {
                typeOfNextLeaf = Random.Range(0, greenLeafChance + orangeLeafChance);
            }
            else
            {
                typeOfNextLeaf = Random.Range(0, greenLeafChance + orangeLeafChance + redLeafChance);
            }
            if (typeOfNextLeaf < greenLeafChance)
            {
                newLeaf = Instantiate(leafPrefab[0]);
                newLeaf.name = "Point_" + numberOfLeaf;
            }
            else
            {
                if (typeOfNextLeaf >= greenLeafChance && typeOfNextLeaf < greenLeafChance + orangeLeafChance)
                {
                    newLeaf = Instantiate(leafPrefab[1]);
                    newLeaf.name = "Point_" + numberOfLeaf;
                }
                else
                {
                    newLeaf = Instantiate(leafPrefab[2]);
                    newLeaf.name = "Point_" + numberOfLeaf;
                }
            }
            string targetValue = "Point_" + (numberOfLeaf - 10);
            GameObject oldLeaf = GameObject.Find(targetValue);
            if (isDestroyLeaf && oldLeaf)
            {
                Destroy(oldLeaf);
            }            
            newLeaf.transform.position = new Vector3(Random.Range(leftBorderWorld, rightBorderWorld), lastLeaf.transform.position.y + Mathf.Max(Random.Range(0, screenHeightWorld / 2), screenHeightWorld / 10), 0);
            lastLeaf = newLeaf;
            numberOfLeaf++;
        }
    }

    public void GenerateFirstPoint()
    {
        GameObject newLeaf;
        newLeaf = Instantiate(leafPrefab[0]);
        newLeaf.transform.position = new Vector3(Random.Range(leftBorderWorld,rightBorderWorld),0,0);
        newLeaf.name = "Point_" + numberOfLeaf;
        numberOfLeaf++;
        lastLeaf = newLeaf;
    }

    public void GenerateNextPoint()
    {
        if (lastLeaf.transform.position.y < cam.transform.position.y + screenHeightWorld / 2)
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
                    newLeaf.transform.position = new Vector3(Random.Range(leftBorderWorld, rightBorderWorld), lastLeaf.transform.position.y + Mathf.Max(Random.Range(0, screenHeightWorld / 2), screenHeightWorld / 10), 0);
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
