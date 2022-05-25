using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    
    Camera cam;
    private float backgroundOffsetToCam ;

    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        //Vector3 botLeftCamCoordinate = cam.ScreenToWorldPoint(0,0,0);
        //float yCamBotCoordinate = botLeftCamCoordinate.y; //нижняя часть камеры
        //float backgroundHalfY = transform.position.y + transform.localScale.y/2;
        backgroundOffsetToCam = transform.localScale.y/2 - cam.localScale.y/2; //нижняя часть бэкграунда
        transform.position.y = cam.transform.position.y + backgroundOffsetToCam;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(transform.position.x, target.position.y+3.38f-target.position.y*0.4f+backgroundOffsetToCam, transform.position.z);
        transform.position = newPos;
    }
}
