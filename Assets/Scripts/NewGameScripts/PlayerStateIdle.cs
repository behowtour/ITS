public class PlayerStateIdle:IPlayerState
{
    public void Enter(Player player)
    {
        player.animator.Play("Idle");
    }

    public void Exit(Player player)
    {
        
    }

    public void Update(Player player, int coordDiff)
    {
        if (player.controller.isMouseHoldOnAnchor)
        {
            player.SetPlayerStateStartJump();
        }
    }
}

