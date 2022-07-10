public class PlayerStateStartJump : IPlayerState
{
    public void Enter(Player player)
    {
        player.animator.Play("StartJump");
    }

    public void Exit(Player player)
    {
        
    }

    void IPlayerState.Update(Player player, int coordDiff)
    {
        if (!player.controller.isMouseHoldOnAnchor)
        {
            player.SetPlayerStateReleasePoint();
        }
    }
}

