using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float camPositionOffset;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Follow()
    {
        Vector3 newPos;
        float coordDiff = Mathf.Abs(target.position.y - transform.position.y);
        if (target.position.y < 0)
        {
            newPos = Vector3.Lerp(transform.position, new Vector3(transform.position.x, 0, transform.position.z), Time.deltaTime * coordDiff);
        }
        else
        {
            newPos = Vector3.Lerp(transform.position, new Vector3(transform.position.x, target.position.y + camPositionOffset, transform.position.z), Time.deltaTime * coordDiff);
        }
        transform.position = newPos;
    }
}
