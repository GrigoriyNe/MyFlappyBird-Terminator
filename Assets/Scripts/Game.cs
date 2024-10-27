using System;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bat _bat;
    [SerializeField] private EnemyGenerator _enemyGenerator;
    [SerializeField] private ScoreGenerator _scoreGenerator;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndGameScreen _endGameScreen;

    public event Action Play;

    private void OnEnable()
    {
        _startScreen.ButtonClicked += OnPlayButtonClick;
        _endGameScreen.ButtonClicked += OnRestartButtonClick;
        _bat.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.ButtonClicked -= OnPlayButtonClick;
        _endGameScreen.ButtonClicked -= OnRestartButtonClick;
        _bat.GameOver -= OnGameOver;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
        _endGameScreen.gameObject.SetActive(false);
        StopAllCoroutines();
        ChangeGenered(false);
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;
        _endGameScreen.Open();
    }

    private void OnRestartButtonClick()
    {
        _endGameScreen.Close();
        StartGame();
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
        _endGameScreen.gameObject.SetActive(true);
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _bat.Reset();
        Play?.Invoke();
        ChangeGenered(true);
    }

    private void ChangeGenered(bool isActive)
    {
        _enemyGenerator.gameObject.SetActive(isActive);
        _scoreGenerator.gameObject.SetActive(isActive);
    }
}
