using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapPointGrassToTreeTransition : Anchor
{
    public GameObject mainCamera;
    GameManager gameManager;
    public GameObject hero;
    Rigidbody2D heroRigid;
    private bool onTapMode;
    [Header("Hero setup")]
    public float heroYToMoveOffset;
    public Vector3 targetPosition;
    public float speed = 0.01f;
    
    [Header("Grass To Tree Prefab")]
    public GameObject grassToTreeTransitionPrefab;
    public float transitionAppearY_Offset;
    [Header("current background")]
    private GameObject currentBackground;
    private Vector3 downfallCurrentBackgroundPosition;
    private float currentBackgroundDownfallOffset;
    public float maxDistanceBackgroundDownfallDelta;

    public override void OnCollision(Collider2D collision)
    {
    }

    public override void OnRelease()
    {
        
    }

    public override void OnTap()
    {


      
        gameManager.onPlay = false;
        heroRigid.simulated = false;
        onTapMode = true;
        Instantiate(grassToTreeTransitionPrefab, new Vector3(0, transform.position.y + transitionAppearY_Offset, 0), Quaternion.Euler(0, 0, 0));

        
        
        
    }
    private void Awake()
    {
        mainCamera = GameObject.Find("Main Camera");
        hero = GameObject.Find("Hero");
        gameManager = mainCamera.GetComponent<GameManager>();
        heroRigid = hero.GetComponent<Rigidbody2D>();
        targetPosition = new Vector3(0,this.transform.position.y + heroYToMoveOffset,0);
        currentBackground = GameObject.Find("CurrentBackground");
        downfallCurrentBackgroundPosition = new Vector3(currentBackground.transform.position.x, currentBackground.transform.position.y - currentBackgroundDownfallOffset, 0);

    }


    private void FixedUpdate()
    {
       if (onTapMode) { 
       hero.transform.position = Vector3.Lerp(hero.transform.position, targetPosition, speed * Time.deltaTime);
            hero.transform.rotation = Quaternion.Lerp(hero.transform.rotation, Quaternion.Euler(0, 0, 0), speed * Time.deltaTime);
            currentBackground.transform.position = Vector3.MoveTowards(currentBackground.transform.position, downfallCurrentBackgroundPosition, maxDistanceBackgroundDownfallDelta);
        }
       



       
    }
}
