using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapPointFade : Anchor
{
    public override void OnCollision(Collider2D collision)
    {
        
    }

    public override void OnRelease()
    {
        Destroy(this.transform.gameObject);
    }

    public override void OnTap()
    {
        
    }
}
