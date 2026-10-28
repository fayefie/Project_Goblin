using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/LevelUpOptionsSO")]
public class LevelUpOptionsSO : ScriptableObject
{
    [Header("Upgrade Information")]
    public string upgradeName;
    [TextArea] public string upgradeDescription;

    [Header("Player Stat Upgrades")]
    public float healthUpgrade;
    public float speedUpgrade;

    [Header("Weapon Stat Upgrades")]
    public float damageUpgrade;
    public float weaponCooldownUpgrade;
    public float weaponSizeUpgrade;
}
