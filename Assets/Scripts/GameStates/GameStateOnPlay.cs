using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateOnPlay : IGameState
{
    public void Enter()
    {
        Debug.Log("OnPlay: ������� � ���������");
    }

    public void Exit()
    {
        Debug.Log("OnPlay: ����� �� ���������");
    }

    public void Update()
    {
        
    }
}
