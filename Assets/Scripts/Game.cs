using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bat _bat;
    [SerializeField] private EnemyGenerator _enemyGenerator;
    [SerializeField] private ScoreGenerator _scoreGenerator;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndGameScreen _endGameScreen;
    [SerializeField] private EnemyPool _enemyPool;
    [SerializeField] private ScorePool _scorePool;
    [SerializeField] private BuletPool _buletPoolEnemy;
    [SerializeField] private BuletPool _buletPoolBat;

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
        _endGameScreen.gameObject.SetActive(false);
        StopAllCoroutines();
    }

    private void OnEnable()
    {
        _startScreen.PlayButtonClicked += OnPlayButtonClick;
        _endGameScreen.RestartButtonClicked += OnRestartButtonClick;
        _bat.GameOver += OnGameOver;
        ChangeGenered(false);
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClicked -= OnPlayButtonClick;
        _endGameScreen.RestartButtonClicked -= OnRestartButtonClick;
        _bat.GameOver -= OnGameOver;
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
        ChangeGenered(true);
        _enemyPool.Reset();
        _scorePool.Reset();
        _buletPoolEnemy.Reset();
        _buletPoolBat.Reset();
    }

    private void ChangeGenered(bool isActive)
    {
        _enemyGenerator.gameObject.SetActive(isActive);
        _scoreGenerator.gameObject.SetActive(isActive);
        _buletPoolEnemy.gameObject.SetActive(isActive);
    }
}
