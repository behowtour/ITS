using System;
public class PlayerStateReleasePoint:IPlayerState
{
    public void Enter(Player player)
    {
        //player.animator.Play("ReleasePoint");
    }

    public void Exit(Player player)
    {
        //throw new NotImplementedException();
    }

    public void Update(Player player, float velocity, float accelerate)
    {
        //if (player.controller.isMouseHoldOnAnchor)
        //{
        //    player.SetPlayerStateClickPoint();
        //}
        //else
        //{
        //    if (velocity < 0)
        //    {
        //        player.SetPlayerStateFallDown();
        //    }
        //}
        player.playerAnimator.SetVelocity(velocity);
        player.playerAnimator.SetAccelerate(accelerate);
    }
}

