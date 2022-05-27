using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public bool CheckGameOver(float camPositionY, float lastPointy, float screenHeightWorld)
    {
        bool isGameOver;
        isGameOver = false;
        if (cam.transform.position.y < lastLeaf.transform.position.y - screenHeightWorld * 2)
        {
            isGameOver true;
        }
        return = isGameOver;
    }
}
