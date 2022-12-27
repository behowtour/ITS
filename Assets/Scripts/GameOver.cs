

public static class GameOver
{
    public static bool isGameOver = false;
    public static void CheckGameOver(float heroPositionY, float lastPointy, float screenHeightWorld)
    {
        //isGameOver = false;
        if (heroPositionY < lastPointy - screenHeightWorld)
        {
            isGameOver = true;
        }
        //return isGameOver;
    }

    public static void CheckGameOver(string tag)
    {
        //isGameOver = false;
        if (tag == "RedLeaf" || tag == "Enemy")
        {
            isGameOver = true;
        }
        //return isGameOver;
    }
}
