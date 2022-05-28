using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private bool isGameOver;
    public bool CheckGameOver(float camPositionY, float lastPointy, float screenHeightWorld)
    {
        isGameOver = false;
        if (camPositionY < lastPointy - screenHeightWorld * 2)
        {
            isGameOver = true;
        }
        return isGameOver;
    }

    public bool CheckGameOver(GameObject hittedAnchor)
    {
        isGameOver = false;
        if (hittedAnchor && hittedAnchor.tag.Contains("RedLeaf"))
        {
            isGameOver = true;
        }
        return isGameOver;
    }
}
