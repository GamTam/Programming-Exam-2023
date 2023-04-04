using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _titlePage;
    [SerializeField] private GameObject _gameOverPage;
    [SerializeField] private TMP_Text _startScoreText;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _highScoreText;

    public static UIManager Instance;

    private void Awake()
    {
        GameManager.GameStarted = false;
        _startScoreText.SetText($"High Score: {GameManager.HighScore}");
        if (Instance == null) Instance = this;
        else Destroy(this);
    }

    public void GameStart()
    {
        _titlePage.SetActive(false);
        _gameOverPage.SetActive(false);
        GameManager.GameStarted = true;
    }

    public void GameOver()
    {
        _scoreText.SetText($"Score: {GameManager.Score}");
        _highScoreText.SetText($"Best: {GameManager.HighScore}");
        _titlePage.SetActive(false);
        _gameOverPage.SetActive(true);
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
