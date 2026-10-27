using UnityEngine;
using UnityEngine.InputSystem;

public class SwordBehaviour : MeleeWeaponBehaviour
{
    private SpriteRenderer spriteRenderer;

    protected override void Awake()
    {
        base.Awake();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        WeaponFacesDirection();
    }

    private void WeaponFacesDirection()
    {
        if (Keyboard.current.aKey.isPressed)
        {
            spriteRenderer.flipX = true;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            spriteRenderer.flipX = false;
        }
    }
}
