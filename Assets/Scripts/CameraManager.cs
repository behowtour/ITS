using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    // CAMERA
    Camera mainCamera;
    [SerializeField]
    float perfectCameraWidth = 2.88f; // Perfect current Main camera Width calculated on the current Scene Sprites sizes (background) and their import values 
    [SerializeField]
    private float camPositionOffset = 1.5f;
    private Vector3 startCameraPosition;
    [SerializeField]
    private float lastCameraMaxHeightPosition;
    private bool cameraIsLocking = false;
    [SerializeField]
    private float camFadingValue= 0.5f;


    [SerializeField]
    Transform ground;

    // HERO
    [SerializeField]
    Transform hero;
   

    private void Awake()
    {
         
        mainCamera = this.GetComponent<Camera>();
        setCameraPositionAndHeight();

    }

    private void Start()
    {
        lastCameraMaxHeightPosition =startCameraPosition.y;
    }

    void FixedUpdate()
    {
     
        FollowTheTarget();
    }

    private void setCameraPositionAndHeight() {

        //set Camera Height
        mainCamera.orthographicSize = perfectCameraWidth / mainCamera.aspect;

        // set start Camera position
        float camYpos = (ground.transform.position.y - ground.GetComponent<SpriteRenderer>().sprite.bounds.size.y / 2 * ground.transform.localScale.y) + mainCamera.orthographicSize; // (ground Position - halfOfSpriteHeight * GroundScale) + halfCamHeight
        startCameraPosition = new Vector3(mainCamera.transform.position.x, camYpos, mainCamera.transform.position.z);
        mainCamera.transform.position = startCameraPosition;
    }

    public void FollowTheTarget()
    {

        // Last hihest camera Y to Lock Camera movement too low
        if (transform.position.y > lastCameraMaxHeightPosition) lastCameraMaxHeightPosition = transform.position.y;
       

        Vector3 newPos;

        // Lerp camera Follow to Hero with constraint near the Ground
        if (hero != null && !cameraIsLocking)
        {
            float coordDiff = Mathf.Abs(hero.position.y - transform.position.y);
            if (transform.position.y < startCameraPosition.y)
            {
                newPos = Vector3.Lerp(transform.position, startCameraPosition, Time.fixedDeltaTime * coordDiff);
            }
            else
            {
                newPos = Vector3.Lerp(transform.position, new Vector3(transform.position.x, Mathf.Clamp(hero.position.y + camPositionOffset, Mathf.Clamp(lastCameraMaxHeightPosition - mainCamera.orthographicSize * camFadingValue, startCameraPosition.y, transform.position.y), hero.position.y + camPositionOffset), transform.position.z), Time.fixedDeltaTime * coordDiff);
            }
            transform.position = newPos;
        } else { Debug.Log("Hero is NULL"); }

        
        

    }
}
