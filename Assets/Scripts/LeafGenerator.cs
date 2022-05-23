using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafGenerator : MonoBehaviour
{
    public float leftBorderWorld, rightBorderWorld, screenHeightWorld;
    public GameObject[] leafPrefab;
    public GameObject lastLeaf; 
    Camera cam;
    int numberOfLeaf;
    int greenLeafChance, orangeLeafChance, redLeafChance;
    
    void Start()
    {
        numberOfLeaf = 1;
        greenLeafChance = 10000;
        orangeLeafChance = 10000;
        redLeafChance = 100000 - greenLeafChance - orangeLeafChance;
        cam = GetComponent<Camera>();
        Vector3 botLeftWorld = cam.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 topRightWorld = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        leftBorderWorld = botLeftWorld.x;
        rightBorderWorld = topRightWorld.x;
        screenHeightWorld = Mathf.Abs(botLeftWorld.y) + Mathf.Abs(topRightWorld.y);
  
        GameObject newLeaf;
        newLeaf = Instantiate(leafPrefab[0]);
        newLeaf.transform.position = new Vector3(Random.Range(leftBorderWorld,rightBorderWorld),0,0);
        newLeaf.name = "LeafGreen_" + numberOfLeaf;
        numberOfLeaf++;
        lastLeaf = newLeaf;
    }

    // Update is called once per frame
    void Update()
    {
        if (lastLeaf.transform.position.y < cam.transform.position.y + screenHeightWorld / 2)
        {
            int typeOfNextLeaf;
            GameObject newLeaf;
            if (lastLeaf.name.Contains("LeafRed"))
            {
                typeOfNextLeaf = Random.Range(0, greenLeafChance+orangeLeafChance);
            }
            else
            {
                typeOfNextLeaf = Random.Range(0, greenLeafChance + orangeLeafChance + redLeafChance);
            }
            if (typeOfNextLeaf < greenLeafChance)
            {
                newLeaf = Instantiate(leafPrefab[0]);
                newLeaf.name = "LeafGreen_" + numberOfLeaf;
            }
            else
            {
                if (typeOfNextLeaf >= greenLeafChance && typeOfNextLeaf< greenLeafChance + orangeLeafChance)
                {
                    newLeaf = Instantiate(leafPrefab[1]);
                    newLeaf.name = "LeafOrange_" + numberOfLeaf;
                }
                else
                {
                    newLeaf = Instantiate(leafPrefab[2]);
                    newLeaf.name = "LeafRed_" + numberOfLeaf;
                }
            }
            //newLeaf = Instantiate(leafPrefab[0]);
            newLeaf.transform.position = new Vector3(Random.Range(leftBorderWorld, rightBorderWorld),lastLeaf.transform.position.y + Mathf.Max(Random.Range(0,screenHeightWorld/2),screenHeightWorld/10),0);
            //newLeaf.name = "Leaf_" + numberOfLeaf;
            lastLeaf = newLeaf;
            numberOfLeaf++;
            string targetValue = "Leaf_" + (numberOfLeaf - 10);
            GameObject oldLeaf = GameObject.Find(targetValue);
            if (oldLeaf)
            {
                Destroy(oldLeaf);
            }
        }
        //if (cam.transform.position.y<lastLeaf.transform.position.y-screenHeightWorld*2)
        //{
        //    Destroy(GameObject.Find("Hero"));
        //}
    }
}
