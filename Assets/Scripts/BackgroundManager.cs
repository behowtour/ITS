using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    //HERO
    [SerializeField]
    private Transform cam;

    //LAYERS REFS
    [SerializeField]
    Transform mainBackgroundLayer;
    public float mainBackgroundScrollingSpeed = 0.060f;

    [SerializeField]
    Transform shadowBackgroundLayer;
    public float shadowBackgroundScrollingSpeed = 1.5f;

    [SerializeField]
    Transform middleBackgroundLayer;
    public float middleBackgroundScrollingSpeed = 0.6f;

    [SerializeField]
    Transform lightBackgroundLayer;
    public float lightBackgroundScrollingSpeed = 0.6f;


    void Update()
    {
        BackgroundLayersTranslate();
        BackgroundLayersRepeat();
        BackgroundLayersDestroy();
    }

    private void BackgroundLayersTranslate() {

        Vector3 newPosMain = new Vector3(mainBackgroundLayer.position.x, cam.position.y - (cam.position.y * mainBackgroundScrollingSpeed), mainBackgroundLayer.position.z);
        mainBackgroundLayer.position = newPosMain;


       Vector3 newPosShadow = new Vector3(shadowBackgroundLayer.position.x, cam.position.y - cam.position.y * shadowBackgroundScrollingSpeed, shadowBackgroundLayer.position.z);
       shadowBackgroundLayer.position = newPosShadow;


       Vector3 newPosLight = new Vector3(lightBackgroundLayer.position.x, cam.position.y - cam.position.y * lightBackgroundScrollingSpeed, lightBackgroundLayer.position.z);
       lightBackgroundLayer.position = newPosLight;


       Vector3 newPosMid = new Vector3(middleBackgroundLayer.position.x, cam.position.y - cam.position.y * middleBackgroundScrollingSpeed, middleBackgroundLayer.position.z);
       middleBackgroundLayer.position = newPosMid;
    }

    private void BackgroundLayersRepeat()
    {
      // Main background

    
    }

    private void BackgroundLayersDestroy()
    {
       
    }
}
