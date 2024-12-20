using System;
using UnityEngine;

[RequireComponent(typeof(BatMover), typeof(ScoreCounter), typeof(BatCollisionHandler))]
public class Bat : MonoBehaviour
{
    private BatMover _batMover;
    private ScoreCounter _scoreCounter;
    private BatCollisionHandler _handler;

    public event Action GameOver;

    private void Awake()
    {
        _scoreCounter = GetComponent<ScoreCounter>();
        _handler = GetComponent<BatCollisionHandler>();
        _batMover = GetComponent<BatMover>();
    }

    private void OnEnable()
    {
        _handler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= ProcessCollision;
    }

    public void Reset()
    {
        _scoreCounter.Reset();
        _batMover.Reset();
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Enemy || interactable is Ground || interactable is Bullet)
        {
            GameOver?.Invoke();
        }
        else if (interactable is Score)
        {
            _scoreCounter.Add();
        }
    }
}
