using UnityEngine;

public class MeleeWeaponBehaviour : MonoBehaviour
{
    public float destroyAfterSeconds;

    public WeaponsSO weaponData;
    // current stats
    protected float currentDamage;
    protected float currentAttackSpeed;
    protected float currentCooldownDuration;

    protected virtual void Awake()
    {
        currentDamage = weaponData.damage;
        currentAttackSpeed = weaponData.attackSpeed;
        currentCooldownDuration = weaponData.cooldownDuration;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    protected virtual void Update()
    {

    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            EnemyBehaviour enemy = col.GetComponent<EnemyBehaviour>();
            enemy.TakeDamage(currentDamage);
        }
    }
}
