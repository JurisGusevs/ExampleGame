using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float attackRange = 0.5f;
    [SerializeField] private float delayBetweenAttacks = 1f;
    [SerializeField] private AudioSource attack;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRen;
    private bool isPlayerInAttackRange = false;

    public bool isTriggered = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRen = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggered)
        {
            if (isPlayerInAttackRange)
            {
                Debug.Log("Turtle is attacking");
                rb.constraints = RigidbodyConstraints2D.FreezePosition;
                animator.SetTrigger("Attack");
            }
            else if (player.transform.position.x < transform.position.x + 0.1f)
            {
                Debug.Log("Turtle running left");
                rb.constraints = RigidbodyConstraints2D.FreezePositionY;
                rb.velocity = new Vector2(-moveSpeed, 0f);
                spriteRen.flipX = false;
            }
            else if (player.transform.position.x > transform.position.x - 0.1f)
            {
                Debug.Log("Turtle running right");
                rb.constraints = RigidbodyConstraints2D.FreezePositionY;
                rb.velocity = new Vector2(moveSpeed, 0f);
                spriteRen.flipX = true;
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    // Example how to implement enemy attack with trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInAttackRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInAttackRange = false;
        }
    }

    public void AttackPlayer()
    {
        attack.Play();
        if (isPlayerInAttackRange)
        {
            GameManager.Instance.LooseLife();
        }
    }
}
