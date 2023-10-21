using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject score;
    [SerializeField] private GameObject startScreen;
    [SerializeField] private TMP_Text scoreText;
    private int scoreValue = 0;

    public static GameManager Instance { get; private set; }

    private void Start()
    {
        Instance = this;
        Time.timeScale = 0f;
    }

    public void DisableStartScreen()
    {
        startScreen.SetActive(false);
        score.SetActive(true);
        Time.timeScale = 1f;
        Debug.Log("Disable start screen");
    }

    public void IncreaseScore()
    {
        scoreValue++;
        scoreText.text = "Score: " + scoreValue;
    }
}
