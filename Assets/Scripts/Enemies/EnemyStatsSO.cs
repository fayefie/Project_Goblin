using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/EnemyStatsSO")]
public class EnemyStatsSO : ScriptableObject
{
    [Header("Enemy Health")]
    public float enemyHealth;

    [Header("Enemy Damage")]
    public float enemyDamage;

    [Header("Enemy Speed")]
    public float movementSpeed;
}
