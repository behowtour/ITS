using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateGameOver : IGameState
{
    public void Enter()
    {
        Debug.Log("GameOver: ������� � ���������");
    }

    public void Exit()
    {
        Debug.Log("GameOver: ����� �� ���������");
    }

    public void Update()
    {
        
    }
}
