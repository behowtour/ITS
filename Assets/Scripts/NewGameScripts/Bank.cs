public class Bank
{
    public delegate void BankHandler(object sender, int oldCoinsValue, int newCoinsValue);
    public event BankHandler OnCoinsValueChangedEvent;

    public int coins { get; private set; }

    public void AddCoins(object sender, int amount)
    {
        var oldCoinsValue = this.coins;
        this.coins += amount;
        this.OnCoinsValueChangedEvent?.Invoke(sender, oldCoinsValue, this.coins);
    }

    public void SpendCoins(object sender, int amount)
    {
        var oldCoinsValue = this.coins;
        this.coins -= amount;
        this.OnCoinsValueChangedEvent?.Invoke(sender, oldCoinsValue, this.coins);
    }

    public bool IsEnoughCoins(int amount)
    {
        return amount <= coins;
    }
}
