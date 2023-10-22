using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleTrigger : MonoBehaviour
{
    private TurtleController turtle;

    // Start is called before the first frame update
    void Start()
    {
        turtle = GetComponentInChildren<TurtleController>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            turtle.isTriggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            turtle.isTriggered = false;
        }
    }
}
