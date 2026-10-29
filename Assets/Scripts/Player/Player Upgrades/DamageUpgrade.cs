using UnityEngine;
using UnityEngine.InputSystem.XR;

[CreateAssetMenu(menuName = "Upgrades/Damage")]
public class DamageUpgrade : LevelUpOptionsSO
{
    public float increasedDamage = 5f;

    public override void Apply(GameObject Player)
    {
        SwordController stats = Player.GetComponentInChildren<SwordController>();

        if (stats == null)
        {
            Debug.LogError("SwordController not found on player!");
            return;
        }

        stats.bonusDamage += increasedDamage;

        Debug.Log($"Damage bonus increased to {stats.bonusDamage}");
    }
}
