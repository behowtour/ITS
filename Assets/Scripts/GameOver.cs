

public static class GameOver
{
    public static bool isGameOver = false;
    public static void CheckGameOver(float camPositionY, float lastPointy, float screenHeightWorld)
    {
        //isGameOver = false;
        if (camPositionY < lastPointy - screenHeightWorld * 3)
        {
            isGameOver = true;
        }
        //return isGameOver;
    }

    public static void CheckGameOver(string tag)
    {
        //isGameOver = false;
        if (tag == "RedLeaf")
        {
            isGameOver = true;
        }
        //return isGameOver;
    }
}
