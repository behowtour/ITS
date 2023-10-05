using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateOnPlay : IGameState
{
    public void Enter()
    {
        Debug.Log("OnPlay: переход в состояние");
    }

    public void Exit()
    {
        Debug.Log("OnPlay: выход из состояния");
    }

    public void Update()
    {
        
    }
}
