using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class SwordController : WeaponController
{

    // current stats
    protected float currentDamage;
    protected float currentAttackSpeed;
    protected float currentCooldownDuration;

    protected override void Awake()
    {
        base.Awake();
        currentDamage = weaponData.damage;
        currentAttackSpeed = weaponData.attackSpeed;
        currentCooldownDuration = weaponData.cooldownDuration;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
    }

    private protected override void Attack()
    {
        base.Attack();
        GameObject spawnedSword = Instantiate(weaponData.prefab);
        spawnedSword.transform.position = transform.position; // sword has same position as player
        spawnedSword.transform.parent = transform;
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyBehaviour enemy = collision.GetComponent<EnemyBehaviour>();
            enemy.TakeDamage(currentDamage);
        }
    }
}
