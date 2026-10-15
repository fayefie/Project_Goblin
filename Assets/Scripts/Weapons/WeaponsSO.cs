using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/WeaponsSO")]
public class WeaponsSO : ScriptableObject
{
    [Header("Weapon Stats")]
    public GameObject prefab;
    public float weaponDamage;
    public float weaponAttackSpeed;
    public float weaponCooldown;
    public int weaponCount;
    public int weaponPierce;
}
