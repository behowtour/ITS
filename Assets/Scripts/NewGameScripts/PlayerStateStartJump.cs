public class PlayerStateStartJump : IPlayerState
{
    public void Enter(Player player)
    {
        //player.animator.Play("StartJump");
        player.playerAnimator.PlayStartJump();
    }

    public void Exit(Player player)
    {
        
    }

    void IPlayerState.Update(Player player, float velocity, float accelerate)
    {
        //if (!player.controller.isMouseHoldOnAnchor)
        //{
        //    player.SetPlayerStateReleasePoint();
        //}
        player.playerAnimator.SetVelocity(velocity);
        player.playerAnimator.SetAccelerate(accelerate);
    }
}

