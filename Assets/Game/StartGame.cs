using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject score;

    public void DisableStartScreen()
    {
        gameObject.SetActive(false);
        score.SetActive(true);
        Debug.Log("Disable start screen");
    }
}
