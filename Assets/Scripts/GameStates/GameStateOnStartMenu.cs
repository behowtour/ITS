using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateOnStartMenu : IGameState
{
    public void Enter()
    {
        Debug.Log("OnStartMenu: ������� � ���������");
    }

    public void Exit()
    {
        Debug.Log("OnStartMenu: ����� �� ���������");
    }

    public void Update()
    {
        
    }
}
