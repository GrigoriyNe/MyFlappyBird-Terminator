using TMPro;
using UnityEngine;

public class ScoreWiever : MonoBehaviour
{
    private const string ScoreTextForWiev = "SCORE: ";

    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _scoreCounter.ScoreChange += ChangeWiev;
    }

    private void OnDisable()
    {
        _scoreCounter.ScoreChange -= ChangeWiev;
    }

    private void ChangeWiev(int score)
    {
        var scoreWiev = score.ToString();
        _text.text = ScoreTextForWiev + scoreWiev;
    }
}
