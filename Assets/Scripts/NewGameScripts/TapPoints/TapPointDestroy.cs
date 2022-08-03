using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapPointDestroy : MonoBehaviour, ITapPoint
{
    private GameOver gameOver;

    public void OnCollision()
    {
        
    }

    public void OnRelease()
    {
        
    }

    public void OnTap()
    {
        gameOver = new GameOver();
        gameOver.CheckGameOver(this.transform.gameObject.tag);
    }

    // Start is called before the first frame update
    void Start()
    {
        gameOver = new GameOver();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
