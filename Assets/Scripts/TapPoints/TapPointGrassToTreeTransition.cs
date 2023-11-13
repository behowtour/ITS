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
    public BackgroundManager backgroundManager;
    [Header("Hero setup")]
    public float heroYToMoveOffset;
    public Vector3 targetPosition;
    public float speed = 0.01f;
    private GameObject toNextLevelObject;
    
    [Header("Grass To Tree Prefab")]
    public GameObject grassToTreeTransitionPrefab;
    public float transitionAppearY_Offset;
    [Header("current background")]
    private GameObject currentBackground;
    private float currentBackgroundDownfallOffset;
    public float maxDistanceBackgroundDownfallDelta;
    public GameObject lvlPrefab;
    private bool finishMode;

    [Header("Animation")]
    private Animation animation;

    public override void OnCollision(Collider2D collision)
    {

      
    }

    public override void OnRelease()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameManager.onPlay = false;
        heroRigid.simulated = false;
        onTapMode = true;
        toNextLevelObject = Instantiate(grassToTreeTransitionPrefab, new Vector3(0, transform.position.y + transitionAppearY_Offset, 0), Quaternion.Euler(0, 0, 0));
        backgroundManager.isTransit = true;

        targetPosition = new Vector3(0, this.transform.position.y + heroYToMoveOffset, 0);
    }


    public override void OnTap()
    { }

   
    
    private void Awake()
    {
        mainCamera = GameObject.Find("Main Camera");
        hero = GameObject.Find("Hero");
        gameManager = mainCamera.GetComponent<GameManager>();
        heroRigid = hero.GetComponent<Rigidbody2D>();
       
        currentBackground = GameObject.Find("CurrentBackground");
       
        backgroundManager = GameObject.Find("BackgroundManager").GetComponent<BackgroundManager>();

      

    }


    private void FixedUpdate()
    {
       if (onTapMode) { 
       hero.transform.position = Vector3.Lerp(hero.transform.position, targetPosition, speed * Time.deltaTime);
            hero.transform.rotation = Quaternion.Lerp(hero.transform.rotation, Quaternion.Euler(0, 0, 0), speed * Time.deltaTime);
            

            if (hero.transform.position.y >= toNextLevelObject.transform.position.y && !finishMode)
            {
                Instantiate(lvlPrefab, currentBackground.transform.position, currentBackground.transform.rotation);
                toNextLevelObject.GetComponent<Animator>().SetInteger("Trigger", 1);
                Destroy(currentBackground);
                gameManager.onPlay = true;
                finishMode = true;
            }
            if (hero.transform.position.y >= targetPosition.y - 2) {

               
                heroRigid.velocity = Vector3.zero;
                heroRigid.simulated = true;
                onTapMode = false;
            }

        }
       

    }

    public override void HittedAnchorReAttached()
    {
       
    }
}
