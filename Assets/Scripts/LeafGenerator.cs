using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafGenerator : MonoBehaviour
{    
    public GameObject[] leafPrefab;
    public int greenLeafChance, orangeLeafChance, redLeafChance;
    public bool isDestroyLeaf;
    public GameObject lastLeaf; 
    
    private Camera cam;
    private int numberOfLeaf;
    private float leftBorderWorld, rightBorderWorld, screenHeightWorld;
    
    void Start()
    {
        numberOfLeaf = 1;
        greenLeafChance = 10000;
        orangeLeafChance = 10000;
        redLeafChance = 100000 - greenLeafChance - orangeLeafChance;
        cam = GetComponent<Camera>();
        // Vector3 botLeftWorld = cam.ScreenToWorldPoint(new Vector3(0, 0, 0));
        // Vector3 topRightWorld = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        // leftBorderWorld = botLeftWorld.x;
        // rightBorderWorld = topRightWorld.x;
        // screenHeightWorld = Mathf.Abs(botLeftWorld.y) + Mathf.Abs(topRightWorld.y);        
    }

    // public bool CheckGameOver()
    // {
    //     if (cam.transform.position.y < lastLeaf.transform.position.y - screenHeightWorld * 2)
    //     {
    //         return true;
    //     }
    //     else
    //     {
    //         return false;
    //     }
    // }

    public void GenerateNextPoint()
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
                newLeaf.name = "Leaf_" + numberOfLeaf;
            }
            else
            {
                if (typeOfNextLeaf >= greenLeafChance && typeOfNextLeaf < greenLeafChance + orangeLeafChance)
                {
                    newLeaf = Instantiate(leafPrefab[1]);
                    newLeaf.name = "Leaf_" + numberOfLeaf;
                }
                else
                {
                    newLeaf = Instantiate(leafPrefab[2]);
                    newLeaf.name = "Leaf_" + numberOfLeaf;
                }
            }
            GameObject oldLeaf = GameObject.Find(targetValue);
            if (isDestroyLeaf && oldLeaf)
            {
                Destroy(oldLeaf);
            }
            //newLeaf = Instantiate(leafPrefab[0]);
            newLeaf.transform.position = new Vector3(Random.Range(leftBorderWorld, rightBorderWorld), lastLeaf.transform.position.y + Mathf.Max(Random.Range(0, screenHeightWorld / 2), screenHeightWorld / 10), 0);
            //newLeaf.name = "Leaf_" + numberOfLeaf;
            lastLeaf = newLeaf;
            numberOfLeaf++;
            string targetValue = "Leaf_" + (numberOfLeaf - 10);
            
        }
    }

    public void GenerateFirstPoint()
    {
        GameObject newLeaf;
        newLeaf = Instantiate(leafPrefab[0]);
        newLeaf.transform.position = new Vector3(Random.Range(leftBorderWorld,rightBorderWorld),0,0);
        newLeaf.name = "Leaf_" + numberOfLeaf;
        numberOfLeaf++;
        lastLeaf = newLeaf;
    }
}
