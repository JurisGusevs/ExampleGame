using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask jumpableGround;
    private Rigidbody2D rb;
    private BoxCollider2D playerCollider;
    [SerializeField] private PlayerInputActions playerInput;

    public bool isAlive = true;

    private void Awake()
    {
        playerInput = new PlayerInputActions();
        playerInput.Player.Enable();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive)
        {
            AudioManager.Instance.OnPlayerDeath();
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            return;
        }
        // Read input from old input system on x axis
        // float xAxis = Input.GetAxis("Horizontal");
        Vector2 axis = playerInput.Player.move.ReadValue<Vector2>();

        rb.velocity = new Vector2(axis.x * movementSpeed, rb.velocity.y);

        // Example from old input system
        /*if (Input.GetButton("Jump") && IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }*/
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }

    private void PlayerDeath()
    {
        GameManager.Instance.EnableGameOverScreen();
        Destroy(gameObject);
    }

    public void JumpAction()
    {
        if (IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
