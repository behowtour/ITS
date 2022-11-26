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
    Transform ground;

    // HERO
    [SerializeField]
    Transform hero;
   

    private void Awake()
    {
        mainCamera = this.GetComponent<Camera>();
        setCameraPositionAndHeight();

    }
    void Start()
    {
        
    }

  
    void Update()
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

      
        Vector3 newPos;
        float coordDiff = Mathf.Abs(hero.position.y - transform.position.y);
        if (hero.position.y < startCameraPosition.y)
        {
            newPos = Vector3.Lerp(transform.position, startCameraPosition, Time.deltaTime * coordDiff);
        }
        else
        {
            newPos = Vector3.Lerp(transform.position, new Vector3(transform.position.x, hero.position.y + camPositionOffset, transform.position.z), Time.deltaTime * coordDiff);
        }
        transform.position = newPos;
    }
}
