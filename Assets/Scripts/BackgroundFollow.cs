using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    private float backgroundOffsetToCam ;
    public Camera cam;
    public Transform target;
    

    void Start()
    {
        var backgroundHeight = GetComponent<SpriteRenderer>().bounds.size.y;
        backgroundOffsetToCam = backgroundHeight / 2 - cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0) ).y; //нижняя часть бэкграунда
        
        Vector3 newPos = new Vector3(transform.position.x, target.transform.position.y + backgroundOffsetToCam, transform.position.z);
        transform.position = newPos;
    }

    
    void Update()
    {
        Vector3 newPos = new Vector3(transform.position.x, target.position.y-target.position.y*0.1f+backgroundOffsetToCam, transform.position.z);
        
        transform.position = newPos;
    }
}
