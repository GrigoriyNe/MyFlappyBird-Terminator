using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int _score = 0;

    public event Action<int> ScoreChange;

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

