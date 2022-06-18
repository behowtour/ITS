using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateOnStartMenu : IGameState
{
    public void Enter()
    {
        Debug.Log("OnStartMenu: переход в состояние");
    }

    public void Exit()
    {
        Debug.Log("OnStartMenu: выход из состояния");
    }

    public void Update()
    {
        
    }
}
