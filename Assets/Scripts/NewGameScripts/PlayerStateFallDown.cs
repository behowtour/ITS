using System;
public class PlayerStateFallDown:IPlayerState
{
    public void Enter(Player player)
    {
        player.animator.Play("FallDown");
    }

    public void Exit(Player player)
    {
        
    }

    public void Update(Player player, int coordDiff)
    {
        if (player.controller.isMouseHoldOnAnchor)
        {
            player.SetPlayerStateClickPoint();
        }
    }
}

