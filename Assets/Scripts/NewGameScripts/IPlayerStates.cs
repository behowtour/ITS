public interface IPlayerState
{
    void Enter(Player player);
    void Exit(Player player);
    void Update(Player player, int coordDiff);
}