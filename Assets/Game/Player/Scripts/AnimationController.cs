using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    [SerializeField] private AudioSource jump;
    [SerializeField] private AudioSource run;
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.isAlive)
        {
            if (Mathf.Abs(rb.velocity.x) > 0.1f && Mathf.Abs(rb.velocity.y) < 1f)
            {
                if (rb.velocity.x > 0.1f) spriteRenderer.flipX = false; else if (rb.velocity.x < -0.1f) spriteRenderer.flipX = true;
                animator.SetTrigger("Run");
                //run.Play();
            }
            else if (rb.velocity.y > 1.5f)
            {
                //run.Stop();
                //jump.Play();
                animator.SetTrigger("Jump");
                if (rb.velocity.x < -0.1f)
                {
                    spriteRenderer.flipX = true;
                }
                else if (rb.velocity.x > 0.1f)
                {
                    spriteRenderer.flipX = false;
                }
            }
            else if (rb.velocity.y < -1.5f)
            {
                animator.SetTrigger("Fall");
                if (rb.velocity.x > 0.1f) spriteRenderer.flipX = false; else if (rb.velocity.x < -0.1f) spriteRenderer.flipX = true;
            }
            else if (Input.GetAxis("Horizontal") == 0f)
            {
                //run.Stop();
                animator.SetTrigger("Idle");
            }
        }
    }
}
