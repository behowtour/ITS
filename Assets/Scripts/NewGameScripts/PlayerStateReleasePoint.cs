using System;
public class PlayerStateReleasePoint:IPlayerState
{
    public void Enter(Player player)
    {
        player.animator.Play("ReleasePoint");
    }

    public void Exit(Player player)
    {
        //throw new NotImplementedException();
    }

    public void Update(Player player, int coordDiff)
    {
        if (player.controller.isMouseHoldOnAnchor)
        {
            player.SetPlayerStateClickPoint();
        }
        else
        {
            if (coordDiff<0)
            {
                player.SetPlayerStateFallDown();
            }
        }
    }
}

