using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateOnPause : IGameState
{
    public void Enter()
    {
        Debug.Log("OnPause: ������� � ���������");
    }

    public void Exit()
    {
        Debug.Log("OnPause: ����� �� ���������");
    }

    public void Update()
    {
        
    }
}
