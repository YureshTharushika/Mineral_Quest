
[System.Serializable]
public class PlayerData
{
    public int coins;
    public float energy;
    public float health;
    public float fireRate;

    public PlayerData(Logic logic)
    {
        coins = logic.coins;
        energy = logic.energy;
        health = logic.health;
        fireRate = logic.fireRate;
    }

    public PlayerData(int coins, float energy, float health, float fireRate) {
        
        this.coins = coins;
        this.energy = energy;
        this.health = health;
        this.fireRate = fireRate;
    }
}
