using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{

    // CAMERA
    [SerializeField]
    Camera mainCamera;
    [SerializeField]
    float cameraAspect;
    [SerializeField]
    float perfectCameraWidth = 2.88f;
   

    //LAYERS REFS
    [SerializeField]
    GameObject mainBackgroundLayer;
    [SerializeField]
    Vector2 mainBackgroundSize;
    [SerializeField]
    GameObject shadowBackgroundLayer;
    [SerializeField]
    GameObject middleBackgroundLayer;
    [SerializeField]
    GameObject lightBackgroundLayer;
    [SerializeField]
    Transform ground;
    [SerializeField]
  

    private void Awake()
    {

        setCameraPositionAndHeight();

    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private void setCameraPositionAndHeight() {

        //set Camera Height
        mainCamera.orthographicSize = perfectCameraWidth / mainCamera.aspect;

        // set start Camera position
        float camYpos = (ground.transform.position.y - ground.GetComponent<SpriteRenderer>().sprite.bounds.size.y / 2 * ground.transform.localScale.y) + mainCamera.orthographicSize; // (ground Position - halfOfSpriteHeight) * GroundScale + halfCamHeight
        Vector3 correctPosition = new Vector3(mainCamera.transform.position.x, camYpos, mainCamera.transform.position.z);
      
        
        mainCamera.transform.position = correctPosition;
    }
}
