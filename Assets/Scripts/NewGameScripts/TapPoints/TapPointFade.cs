using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapPointFade : MonoBehaviour, ITapPoint
{
    public void OnCollision()
    {
        
    }

    public void OnRelease()
    {
        Destroy(this.transform.gameObject);
    }

    public void OnTap()
    {
        
    }
}
