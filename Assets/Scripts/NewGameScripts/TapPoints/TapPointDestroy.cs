using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapPointDestroy : Anchor
{

    public override void OnCollision(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //<start animation>
            GameOver.CheckGameOver(this.transform.gameObject.tag);
        }
    }

    public override void OnRelease()
    {
        
    }

    public override void OnTap()
    { 
        GameOver.CheckGameOver(this.transform.gameObject.tag);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            OnCollision(collision);
    }
}
