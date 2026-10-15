using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/WeaponsSO")]
public class WeaponsSO : ScriptableObject
{
    [Header("Weapon Stats")]
    public GameObject prefab;
    public float damage;
    public float attackSpeed;
    public float cooldownDuration;
    public int count;
    public int pierce;
}
