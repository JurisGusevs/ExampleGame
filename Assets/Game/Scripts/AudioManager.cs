using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource startScreenMusic;
    [SerializeField] private AudioSource gameMusic;

    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void DisableStartScreen()
    {
        startScreenMusic.Stop();
        gameMusic.Play();
    }

    public void OnPlayerDeath()
    {
        gameMusic.Stop();
    }
}
