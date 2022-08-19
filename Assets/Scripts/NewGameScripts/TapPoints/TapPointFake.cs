using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapPointFake : Anchor
{
    public override void OnCollision(Collider2D collision)
    {
    }

    public override void OnRelease()
    {
    }

    public override void OnTap()
    {
        //<start animation>
        Destroy(this.transform.gameObject);
        base.OnMouseUp();
    }
}
