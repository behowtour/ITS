using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorns : Anchor
{
   
    [Header("ReAttachedAnchor, NOT Dynamic")]
    [SerializeField]
    GameObject thornsAnchor;
    public override void OnCollision(Collider2D collision)
    {
        
    }

    public override void OnRelease()
    {
     
    }

    public override void OnTap()
    {
     

    }

    public override void HittedAnchorReAttached()
    {
        ;

        Vector3 mousePos =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        thornsAnchor.transform.position = mousePos;
        mainController.hittedAnchor = thornsAnchor;
        particleObject.transform.position = thornsAnchor.transform.position;
    }

    

    
}
