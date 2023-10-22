using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            GameManager.Instance.FellInWater();
            player.GetComponent<PlayerMovement>().isAlive = false;
            player.GetComponent<Animator>().SetTrigger("Death");
        }
    }
}
