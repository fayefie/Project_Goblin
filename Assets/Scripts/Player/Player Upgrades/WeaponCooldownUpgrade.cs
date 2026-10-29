using UnityEngine;
using UnityEngine.InputSystem.XR;

[CreateAssetMenu(menuName = "Upgrades/Cooldown")]
public class WeaponCooldownUpgrade : LevelUpOptionsSO
{
    public float decreasedCooldown = 0.2f;
    public override void Apply(GameObject Player)
    {
        SwordController stats = Player.GetComponentInChildren<SwordController>();

        if (stats == null)
        {
            Debug.LogError("SwordController not found on player!", Player);
            return;
        }

        stats.cooldownReduction += decreasedCooldown;

        Debug.Log($"Cooldown reduction: {stats.cooldownReduction}");
    }
}
