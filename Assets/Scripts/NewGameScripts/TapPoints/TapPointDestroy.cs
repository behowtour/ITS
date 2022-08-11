using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapPointDestroy : MonoBehaviour, ITapPoint
{

    public void OnCollision()
    {
        GameOver.CheckGameOver(this.transform.gameObject.tag);
    }

    public void OnRelease()
    {
        
    }

    public void OnTap()
    { 
        GameOver.CheckGameOver(this.transform.gameObject.tag);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            OnCollision();
        }
    }
}
