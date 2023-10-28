using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
   

    //MAIN CAMERA
    [SerializeField]
    Camera mainCam;
    [SerializeField]
    private Transform cam;
    float cameraYLastPos = 0f;
 

    public bool isTransit;
  

    //LAYERS REFS
   [SerializeField]
    Transform mainBackgroundLayer;
    [SerializeField]
    Transform mainBackgroundLayerTop;
    [SerializeField]
    Transform mainBackgroundLayerBottom;
    public float mainBackgroundScrollingSpeed = 0.96f;

    [SerializeField]
    Transform shadowBackgroundLayer;
    public float shadowBackgroundScrollingSpeed = 1.5f;

    [SerializeField]
    Transform middleBackgroundLayer;
    public float middleBackgroundScrollingSpeed = 0.6f;

    [SerializeField]
    Transform lightBackgroundLayer;
    public float lightBackgroundScrollingSpeed = 0.6f;
    private float downfallSpeedForTransition = 0f;


    private void Awake()
    {
       
        cam = GameObject.Find("Main Camera").transform;
    }


    void Update()
    {
        
            BackgroundLayersMove();
        if (isTransit) downfallSpeedForTransition = 0.1f;
        else downfallSpeedForTransition = 0;






    }

    private void BackgroundLayersMove() {

        // Cam Frame Step
        float cameraFrameStep = cam.position.y - cameraYLastPos;
        cameraYLastPos = cam.position.y;

        // MAIN BG INFINETE MOVE

        // BG Move
        Vector3 newPosMain = new Vector3(mainBackgroundLayer.position.x, mainBackgroundLayer.position.y +  cameraFrameStep * mainBackgroundScrollingSpeed - downfallSpeedForTransition* mainBackgroundScrollingSpeed, mainBackgroundLayer.position.z);
        mainBackgroundLayer.position = newPosMain;
            // BG Relocate 
        if (cam.position.y > mainBackgroundLayerTop.position.y) {
            mainBackgroundLayer.position = new Vector3(mainBackgroundLayer.position.x, cam.position.y + mainBackgroundLayerTop.localPosition.y, mainBackgroundLayer.position.z);
           
        }

        // SHADOW BG INFINITE MOVE

            // Shadow move
        Vector3 newPosShadow = new Vector3(shadowBackgroundLayer.position.x,shadowBackgroundLayer.position.y  + cameraFrameStep * shadowBackgroundScrollingSpeed + downfallSpeedForTransition* shadowBackgroundScrollingSpeed, shadowBackgroundLayer.position.z);
        shadowBackgroundLayer.position = newPosShadow;
        // Shadow Relocate
        if (cam.position.y > shadowBackgroundLayer.GetChild(0).transform.position.y) {
            
            shadowBackgroundLayer.position = new Vector3(shadowBackgroundLayer.position.x, shadowBackgroundLayer.position.y + shadowBackgroundLayer.GetChild(0).transform.localPosition.y - shadowBackgroundLayer.GetChild(shadowBackgroundLayer.childCount - 1).transform.localPosition.y, shadowBackgroundLayer.position.z);
        }

        // LIGHT BG INFINITE MOVE

            // Light BG Move
        Vector3 newPosLight = new Vector3(lightBackgroundLayer.position.x, lightBackgroundLayer.position.y + cameraFrameStep * lightBackgroundScrollingSpeed - downfallSpeedForTransition* lightBackgroundScrollingSpeed, lightBackgroundLayer.position.z);
        lightBackgroundLayer.position = newPosLight;
        // Light BG Relocate
        if (cam.position.y > lightBackgroundLayer.GetChild(0).transform.position.y)
        {

            lightBackgroundLayer.position = new Vector3(lightBackgroundLayer.position.x, lightBackgroundLayer.position.y + lightBackgroundLayer.GetChild(0).transform.localPosition.y - lightBackgroundLayer.GetChild(lightBackgroundLayer.childCount - 1).transform.localPosition.y, lightBackgroundLayer.position.z);
        }

        // MIDDLE BG INFINITE MOVE

        // Middle BG Move
        Vector3 newPosMid = new Vector3(middleBackgroundLayer.position.x, middleBackgroundLayer.position.y - downfallSpeedForTransition, middleBackgroundLayer.position.z);
        middleBackgroundLayer.position = newPosMid;
        // Light BG Relocate
       
    }

    private void BackgroundDownfalltoChangeLvl() { 
    
    
    }

}
