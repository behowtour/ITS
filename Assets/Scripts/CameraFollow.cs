using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoFollow
{
    public void Follow(Transform target, Transform followObject, float camPositionOffset)
    {

        // target = Hero          FollowObject = Camera    CamPositionOffset = 1.5f (24//11//22)
        Vector3 newPos;
        float coordDiff = Mathf.Abs(target.position.y - followObject.position.y);
        if (target.position.y < 0)
        {
            newPos = Vector3.Lerp(followObject.position, new Vector3(followObject.position.x, 0, followObject.position.z), Time.deltaTime * coordDiff);
        }
        else
        {
            newPos = Vector3.Lerp(followObject.position, new Vector3(followObject.position.x, target.position.y + camPositionOffset, followObject.position.z), Time.deltaTime * coordDiff);
        }
        followObject.position = newPos;
    }
}
