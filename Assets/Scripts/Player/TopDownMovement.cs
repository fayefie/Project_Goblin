using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(Rigidbody2D))]
public class TopDownMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    [SerializeField] private InputActionReference moveActionReference;
    [HideInInspector] public bool isPlayerMoving = false;
    private SpriteRenderer spriteRenderer;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        playerFacesDirection();
    }

    private void OnEnable()
    {
        moveActionReference.action.Enable();
        moveActionReference.action.performed += OnMovePerformed;
        moveActionReference.action.canceled += OnMoveCanceled;
    }

    private void OnDisable()
    {
        moveActionReference.action.performed -= OnMovePerformed;
        moveActionReference.action.canceled -= OnMoveCanceled;
        moveActionReference.action.Disable();
    }

    private void OnMovePerformed(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
        isPlayerMoving = true;
    }

    private void OnMoveCanceled(InputAction.CallbackContext ctx)
    {
        moveInput = Vector2.zero;
        isPlayerMoving = false;
    }

    private void playerFacesDirection()
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
