using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScoreObject")]
public class ExampleScripttableObject : ScriptableObject
{
    public int score;
    private int test;
    public Vector3 position;
    public Sprite sprite;

    public void PrintScore()
    {
        Debug.Log("Score is: " + score);
    }
}
