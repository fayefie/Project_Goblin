using UnityEngine;
using UnityEngine.InputSystem;

public class SwordBehaviour : MeleeWeaponBehaviour
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D bc2d;

    protected override void Awake()
    {
        base.Awake();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        bc2d = GetComponentInChildren<BoxCollider2D>();
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
        if (TopDownMovement.facingLeft == true)
        {
            spriteRenderer.flipX = true;
            bc2d.offset = new Vector2(-0.8656738f, -0.02292132f);
        }
        else if (TopDownMovement.facingLeft == false)
        {
            spriteRenderer.flipX = false;
            bc2d.offset = new Vector2(0.8656738f, -0.02292132f);
        }
    }
}
