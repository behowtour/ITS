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
        SetTriggerParameter();
        //DestroyThisAnchor();
    }

    public override void OnTap()
    {
        
    }

    public override void HittedAnchorReAttached()
    {
        
    }

    public void SetTriggerParameter()
    {
        Animator animator = transform.GetComponent<Animator>();
        animator.SetTrigger("TriggerFade");
    }
}
