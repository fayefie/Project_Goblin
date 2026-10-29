using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/Health")]
public class HealthUpgrade : LevelUpOptionsSO
{
    public float increasedHealth = 20f;
    public override void Apply(GameObject Player)
    {
        PlayerStats stats = Player.GetComponent<PlayerStats>();

        stats.maxHealth += increasedHealth;
    }
}
