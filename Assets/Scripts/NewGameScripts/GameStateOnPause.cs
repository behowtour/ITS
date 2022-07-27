using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateOnPause : IGameState
{
    public void Enter()
    {
        Debug.Log("OnPause: переход в состояние");
    }

    public void Exit()
    {
        Debug.Log("OnPause: выход из состояния");
    }

    public void Update()
    {
        
    }
}
