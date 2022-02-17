using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafGenerator : MonoBehaviour
{
    private Vector2 leafCoordinates;
    private float genX, genY, topScreen, quaterScreen, midScreen, botScreen;
    public float leftBorderWorld, rightBorderWorld, screenHeightWorld;
    public GameObject leafPrefab;
    public GameObject lastLeaf; 
    Camera cam;
    bool create = true;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        //genX = Random.Range(0, Screen.width);
        //genY = Screen.height / 2;
        Vector3 botLeftWorld = cam.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 topRightWorld = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        leftBorderWorld = botLeftWorld.x;
        rightBorderWorld = topRightWorld.x;
        screenHeightWorld = Mathf.Abs(botLeftWorld.y) + Mathf.Abs(topRightWorld.y);
        
        float nearClipPlane = cam.nearClipPlane;
        GameObject newLeaf;
        newLeaf = Instantiate(leafPrefab);
        newLeaf.transform.position = new Vector3(Random.Range(leftBorderWorld,rightBorderWorld),0,0);
        lastLeaf = newLeaf;
    }

    // Update is called once per frame
    void Update()
    {
        //topScreen = Screen.height;
        //quaterScreen = Screen.height - Screen.height / 4;
        //midScreen = Screen.height / 2;
        //botScreen = 0;
        //Vector3 quaterScreenWorld =cam.ScreenToWorldPoint(new Vector3(0, quaterScreen, cam.nearClipPlane));

        if (lastLeaf.transform.position.y<cam.transform.position.y + screenHeightWorld/2)
        {
            //genX = Random.Range(0, Screen.width);
            //genY = Screen.height / 16 + Random.Range(0,Screen.height - quaterScreen);
            //leafCoordinates = new Vector2(genX, genY);
            //float nearClipPlane = cam.nearClipPlane;
            //leafCoordinates = cam.ScreenToWorldPoint(new Vector3(leafCoordinates.x, leafCoordinates.y, nearClipPlane));
            //leafCoordinates.y = Mathf.Abs(leafCoordinates.y) + lastLeaf.transform.position.y;
            GameObject newLeaf;
            newLeaf = Instantiate(leafPrefab);
            newLeaf.transform.position = new Vector3(Random.Range(leftBorderWorld, rightBorderWorld),lastLeaf.transform.position.y + Random.Range(0,screenHeightWorld/2) + screenHeightWorld/10,0);
            lastLeaf = newLeaf;
        }

        //if (create)
        //{
        //    genX = Random.RandomRange(0, Screen.width);
        //    genY = Screen.height / 2;
        //    leafCoordinates = new Vector2(genX, genY);
        //    float nearClipPlane = 0;
        //    leafCoordinates = cam.ScreenToWorldPoint(new Vector3(leafCoordinates.x, leafCoordinates.y, nearClipPlane));
        //    GameObject newLeaf;
        //    newLeaf = Instantiate(leafPrefab);
        //    newLeaf.transform.position = leafCoordinates;
        //}
        //create = false;
    }
}
