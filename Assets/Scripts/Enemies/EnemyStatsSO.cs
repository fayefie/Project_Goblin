using UnityEngine;

[CreateAssetMenu(menuName = "EnemyStatsSO")]
public class EnemyStatsSO : ScriptableObject
{
    [Header("Enemy Health")]


    [Header("Enemy Damage")]
    public float damageDealt;

    [Header("Enemy Speed")]
    public float movementSpeed;
    
}
