using UnityEngine;

public class FlyingLeaf : MonoBehaviour
{
    public float MoveTime; // чем больше тем медленнее движется
    
    [SerializeField] private float MoveWidth;
    [SerializeField] private float MoveHeight;

    private float InitialPosY;
    private float UpdateTime;
    private Vector2 RandomPos;

    private Vector2 GenerateRandom(float PosY)
    {
        System.Random rnd = new System.Random();
        float rndX = rnd.Next(((int)-MoveWidth*10) / 2, ((int)MoveWidth*10) / 2);
        float rndY = rnd.Next(((int)-MoveHeight*10) / 2, ((int)MoveHeight*10) / 2);
        rndX = rndX * 0.1f;
        rndY = rndY * 0.1f + PosY;

        return new Vector2(rndX,rndY);
    }

    private void OnEnable()
    {
        UpdateTime = 0f;
    }
    void Start()
    {
        InitialPosY = transform.position.y;
        RandomPos = GenerateRandom(InitialPosY);
    }
    private void FixedUpdate()
    {
        if((Vector2)transform.position != RandomPos)
                                                      
        {
            UpdateTime += Time.deltaTime;
            transform.position = Vector2.Lerp(transform.position, RandomPos, UpdateTime * MoveTime);
        }
        else
        {
            UpdateTime = 0f;
            RandomPos = GenerateRandom(InitialPosY);
        }

    }
}
