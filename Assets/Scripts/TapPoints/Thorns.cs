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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        audioSource.PlayOneShot(audioClip_Collision);
        if (collision.gameObject.tag == "Player")
        {
            //<start animation>
            GameOver.CheckGameOver(this.transform.gameObject.tag);
        }
    }



}
