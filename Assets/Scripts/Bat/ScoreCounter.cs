using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int _score;

    public event Action<int> ScoreChange;

    private void Awake()
    {
        _score = 0;
    }

    public void Reset()
    {
        _score = 0;
        ScoreChange?.Invoke(_score);
    }

    public void Add()
    {
        _score++;
        ScoreChange?.Invoke(_score);
    }
}

