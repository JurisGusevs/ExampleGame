using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadSceneOnButtonClick()
    {
        SceneManager.LoadScene(1);
    }
}
