using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpTrigger : MonoBehaviour
{

    public GameObject hero;
    public int heightPoint;
    public GameObject pointPrefab;
    bool levelchanged;
    public int transitionPointPositionOffset;

    void Start()
    {
      
    }


    void Update()
    {
          if (!levelchanged) { 
             if (hero.transform.position.y > heightPoint) {
                Vector3 transitionTriggerPointPosition = new Vector3(0, hero.transform.position.y + transitionPointPositionOffset, 0);
            Instantiate(pointPrefab, transitionTriggerPointPosition, transform.rotation);
                levelchanged = true;
             }
          }
    }
}
