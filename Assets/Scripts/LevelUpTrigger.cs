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
    private GameObject lvlSeparatePrefab;
    public GameObject lvlPrefab;
    private GameObject currentLvl;
    private bool lvlAfterChanged;

    void Start()
    {
      
    }


    void Update()
    {
          if (!levelchanged) { 
             if (hero.transform.position.y > heightPoint) {
                Vector3 transitionTriggerPointPosition = new Vector3(0, hero.transform.position.y + transitionPointPositionOffset, 0);
            lvlSeparatePrefab = Instantiate(pointPrefab, transitionTriggerPointPosition, transform.rotation);
                levelchanged = true;
             }
          }
       
    }
}
