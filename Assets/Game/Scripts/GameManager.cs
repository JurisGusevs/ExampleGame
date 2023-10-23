using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject overlay;
    [SerializeField] private GameObject startScreen;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private int lifes = 3;
    [SerializeField] private TMP_Text lifesText;
    private int scoreValue = 0;
    
    public static GameManager Instance { get; private set; }

    private void Start()
    {
        Instance = this;
        if (gameObject.scene.buildIndex == 0)
        {
            Time.timeScale = 0f;
        }
        lifesText.text = "Lifes: " + lifes;
    }

    public void DisableStartScreen()
    {
        if (startScreen != null)
        {
            //startScreen.SetActive(false);
            StartCoroutine(Fade());
        }
        overlay.SetActive(true);
        Time.timeScale = 1f;
        Debug.Log("Disable start screen");
    }

    // Example of how to use coroutine inside of Unity
    IEnumerator Fade()
    {
        for (float scale = 1f; scale >= 0.01f; scale -= 0.01f)
        {
            startScreen.transform.localScale = new Vector3(scale, scale, scale);
            yield return new WaitForSeconds(0.005f);
        }
        startScreen.SetActive(false);
        yield return null;
    }

    public void IncreaseScore()
    {
        scoreValue++;
        scoreText.text = "Score: " + scoreValue;
    }

    public void EnableGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(gameObject.scene.name);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    public void LooseLife()
    {
        if (lifes > 0)
        {
            lifes--;
            lifesText.text = "Lifes: " + lifes;
            if (lifes <= 0)
            {
                // Example use to find game object, make sure the tag doesn't change
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                player.GetComponent<PlayerMovement>().isAlive = false;
                player.GetComponent<Animator>().SetTrigger("Death");
            }
        }
    }

    public void FellInWater()
    {
        lifes = 0;
        lifesText.text = "Lifes: " + lifes;
    }
}
