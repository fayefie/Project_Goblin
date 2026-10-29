using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class SwordController : WeaponController
{
    public SwordBehaviour CurrentSword { get; private set; }

    public float bonusDamage = 0f;
    public float cooldownReduction = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();

        currentCooldown = Mathf.Max(0.05f, weaponData.cooldownDuration - cooldownReduction);
    }

    private protected override void Attack()
    {
        base.Attack();

        currentCooldown = Mathf.Max(0.05f, weaponData.cooldownDuration - cooldownReduction);

        GameObject spawnedSword = Instantiate(weaponData.prefab);

        CurrentSword = spawnedSword.GetComponent<SwordBehaviour>();

        spawnedSword.transform.position = transform.position; // sword has same position as player
        spawnedSword.transform.parent = transform;

        if (CurrentSword != null)
        {
            CurrentSword.currentDamage += bonusDamage;
        }
    }
}
