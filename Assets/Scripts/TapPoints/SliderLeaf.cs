using UnityEngine;

public class SliderLeaf : MonoBehaviour
{
    private int Direction;
    public float Speed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "MainCamera")
        {
            Direction = Direction * -1;
        }
    }

    private void OnEnable()
    {
        Direction = 1;
    }

    private void FixedUpdate()
    { 
        transform.Translate(transform.right.normalized * Direction * Speed);
    }
}
