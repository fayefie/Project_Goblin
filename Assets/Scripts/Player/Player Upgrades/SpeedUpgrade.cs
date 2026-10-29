using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/Speed")]
public class SpeedUpgrade : LevelUpOptionsSO
{
    public float increasedSpeed = 0.5f;
    public override void Apply(GameObject Player)
    {
        TopDownMovement stats = Player.GetComponent<TopDownMovement>();

        stats.moveSpeed += increasedSpeed;
    }
}
