using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapPointFake : Anchor
{
    private SpriteRenderer spriteRenderer;
    public override void OnCollision(Collider2D collision)
    {
    }

    public override void OnRelease()
    {
    }

    public override void OnTap()
    {
        //<start animation>

        transform.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        base.OnMouseUp();
        //Destroy(this.transform.gameObject);

    }
}
