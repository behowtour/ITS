using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public bool CheckGameOver(float camPositionY, float lastPointy, float screenHeightWorld)
    {
        bool isGameOver;
        isGameOver = false;
        if (camPositionY < lastPointy - screenHeightWorld * 2)
        {
            isGameOver = true;
        }
        return isGameOver;
    }
}
