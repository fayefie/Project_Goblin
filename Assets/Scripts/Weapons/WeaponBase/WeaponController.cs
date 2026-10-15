using System;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public WeaponsSO weaponData;
    public float currentCooldown;

    protected virtual void Awake()
    {

    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        currentCooldown = weaponData.cooldownDuration; // wait for cooldown before attacking
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        currentCooldown -= Time.deltaTime;
        if (currentCooldown <= 0f) // once cooldown reaches zero, attack
        {
            Attack();
        }
    }

    protected virtual private void Attack()
    {
        currentCooldown = weaponData.cooldownDuration;
    }
}
