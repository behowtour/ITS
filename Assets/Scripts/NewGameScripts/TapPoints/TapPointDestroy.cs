using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapPointDestroy : MonoBehaviour, ITapPoint
{

    public void OnCollision()
    {
        
    }

    public void OnRelease()
    {
        
    }

    public void OnTap()
    { 
        GameOver.CheckGameOver(this.transform.gameObject.tag);
    }

    void Start()
    {

    }

    void Update()
    {
        
    }
}
