using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.05f;
    [SerializeField] private float maxXaxis = 3f;
    [SerializeField] private float minXaxis = -1.5f;
    [SerializeField] private GameObject player;

    private void FixedUpdate()
    {
        if (transform.position.x > maxXaxis)
        {
            moveSpeed = -moveSpeed;
        } 
        else if (transform.position.x < minXaxis)
        {
            moveSpeed = -moveSpeed;
        }
        transform.position += new Vector3(moveSpeed, 0f, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            player.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            player.transform.SetParent(null);
        }
    }
}
