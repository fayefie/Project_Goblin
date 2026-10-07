using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/EnemyStatsSO")]
public class EnemyStatsSO : ScriptableObject
{
    [Header("Enemy Health")]
    public float enemyHealth;

    [Header("Enemy Damage")]
    public float damageDealt;

    [Header("Enemy Speed")]
    public float movementSpeed;

    [Header("Enemy XP")]
    public float droppedXP;
    [HideInInspector] public float droppedXPSmall = 10.0f;
    [HideInInspector] public float droppedXPMedium = 30.0f;
    [HideInInspector] public float droppedXPLarge = 100.0f;
}
