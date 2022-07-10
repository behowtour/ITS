using System;
public class PlayerStateClickPoint : IPlayerState
{
    public void Enter(Player player)
    {
        player.animator.Play("ClickPoint");
    }

    public void Exit(Player player)
    {
        //throw new NotImplementedException();
    }

    public void Update(Player player, int coordDiff)
    {
        if (!player.controller.isMouseHoldOnAnchor)
        {
            player.SetPlayerStateReleasePoint();
        }
    }
}

