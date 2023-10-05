using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapPointGrassToTreeTransition : Anchor
{
    public Camera mainCamera;
    public PointsGenerator pointsGenerator;


   
    public override void OnCollision(Collider2D collision)
    {
    }

    public override void OnRelease()
    {
        
    }

    public override void OnTap()
    {
        
    }
    private void Awake()
    {
        pointsGenerator = FindObjectOfType<PointsGenerator>();
    }
}
