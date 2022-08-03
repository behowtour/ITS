

public class GameOver
{
    public bool isGameOver = false;
    public void CheckGameOver(float camPositionY, float lastPointy, float screenHeightWorld)
    {
        //isGameOver = false;
        if (camPositionY < lastPointy - screenHeightWorld * 3)
        {
            isGameOver = true;
        }
        //return isGameOver;
    }

    public void CheckGameOver(string tag)
    {
        //isGameOver = false;
        if (tag == "RedLeaf")
        {
            isGameOver = true;
        }
        //return isGameOver;
    }
}
