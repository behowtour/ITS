using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateGameOver : IGameState
{
    public void Enter()
    {
        Debug.Log("GameOver: переход в состояние");
    }

    public void Exit()
    {
        Debug.Log("GameOver: выход из состояния");
    }

    public void Update()
    {
        
    }
}
