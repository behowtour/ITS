using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafGenerator : MonoBehaviour
{
    public float leftBorderWorld, rightBorderWorld, screenHeightWorld;
    public GameObject leafPrefab;
    public GameObject lastLeaf; 
    Camera cam;
    
    void Start()
    {
        cam = GetComponent<Camera>();
        Vector3 botLeftWorld = cam.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 topRightWorld = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        leftBorderWorld = botLeftWorld.x;
        rightBorderWorld = topRightWorld.x;
        screenHeightWorld = Mathf.Abs(botLeftWorld.y) + Mathf.Abs(topRightWorld.y);
  
        GameObject newLeaf;
        newLeaf = Instantiate(leafPrefab);
        newLeaf.transform.position = new Vector3(Random.Range(leftBorderWorld,rightBorderWorld),0,0);
        lastLeaf = newLeaf;
    }

    // Update is called once per frame
    void Update()
    {
        if (lastLeaf.transform.position.y<cam.transform.position.y + screenHeightWorld/2)
        {
            GameObject newLeaf;
            newLeaf = Instantiate(leafPrefab);
            newLeaf.transform.position = new Vector3(Random.Range(leftBorderWorld, rightBorderWorld),lastLeaf.transform.position.y + Random.Range(0,screenHeightWorld/2) + screenHeightWorld/10,0);
            lastLeaf = newLeaf;
        }
    }
}
