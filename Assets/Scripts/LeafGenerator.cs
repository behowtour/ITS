using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafGenerator : MonoBehaviour
{
    private Vector2 leafCoordinates;
    private float genX, genY, topScreen, quaterScreen, midScreen, botScreen;
    public GameObject leafPrefab;
    public GameObject lastLeaf;
    Camera cam;
    bool create = true;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        genX = Random.Range(0, Screen.width);
        genY = Screen.height / 2;
        leafCoordinates = new Vector2(genX, genY);
        float nearClipPlane = 0;
        leafCoordinates = cam.ScreenToWorldPoint(new Vector3(leafCoordinates.x, leafCoordinates.y, nearClipPlane));
        GameObject newLeaf;
        newLeaf = Instantiate(leafPrefab);
        newLeaf.transform.position = leafCoordinates;
        lastLeaf = newLeaf;
    }

    // Update is called once per frame
    void Update()
    {
        topScreen = Screen.height;
        quaterScreen = Screen.height - Screen.height / 4;
        midScreen = Screen.height / 2;
        botScreen = 0;
        Vector3 quaterScreenWorld =cam.ScreenToWorldPoint(new Vector3(0, quaterScreen, cam.nearClipPlane));

        if (lastLeaf.transform.position.y<quaterScreenWorld.y)
        {
            genX = Random.Range(0, Screen.width);
            genY = Screen.height / 16 + Random.Range(0,Screen.height - quaterScreen);
            leafCoordinates = new Vector2(genX, genY);
            float nearClipPlane = cam.nearClipPlane;
            leafCoordinates = cam.ScreenToWorldPoint(new Vector3(leafCoordinates.x, leafCoordinates.y, nearClipPlane));
            leafCoordinates.y = Mathf.Abs(leafCoordinates.y) + lastLeaf.transform.position.y;
            GameObject newLeaf;
            newLeaf = Instantiate(leafPrefab);
            newLeaf.transform.position = leafCoordinates;
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
