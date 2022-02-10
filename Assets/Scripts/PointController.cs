using UnityEngine;
using System.Collections;
public class PointController : MonoBehaviour
{
    public bool onZone;
    Collider failZone;
    Vector3 lastCursorPosition = Vector3.zero;
    Vector3 cursorPosition;
    Vector3 pointPosition;
    Vector3 pointPositionStep;

    private bool firstFrame = true;
    Vector3 offset;
    void Start()
    {
        pointPosition = transform.position;
        
       
    }
    void Update()
    {
        
        if (Input.GetMouseButton(0))
      
        {

            pointPosition = transform.position;



            // FIND STEP VECTOR FOR POINT
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "Anchor")
                {
                    cursorPosition = hit.point;
                    if (lastCursorPosition != Vector3.zero)
                    {
                        pointPositionStep = cursorPosition - lastCursorPosition;
                        pointPositionStep.z = 0;

                    }
                    else pointPositionStep = Vector3.zero;
                    lastCursorPosition = cursorPosition;

                }

                pointPosition += pointPositionStep;
                transform.position = pointPosition;
            }



        }
        else lastCursorPosition = Vector3.zero;


        //  POINT ON MOUSE
            /*    if (Input.GetMouseButton(0)) 

                {
                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out hit))
                    {
                        zeroCursorPosition = hit.point;
                        transform.position = zeroCursorPosition;
                    }
                } */






    } 

    private void OnCollisionEnter2D(Collision2D collision)
    {
      //  Destroy(gameObject); 
        if (collision.gameObject.tag == "FailZone")
        {
            Destroy(gameObject); 
        }
    }
}