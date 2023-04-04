using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private void Awake()
    {
        GameManager.Score = 0;
        if (Instance == null) Instance = this;
        else Destroy(this);
    }

    public void IncrementScore()
    {
        GameManager.Score += 1;
    } 
}
