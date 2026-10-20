using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class SwordController : WeaponController
{





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
}
