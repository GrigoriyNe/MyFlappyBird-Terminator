using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Enemy : SpawnerableObject, IInteractable
{
    [SerializeField] private float _shootDealayValue = 1;
    [SerializeField] private AttackerEnemy _attacker;
    [SerializeField] private SpriteObjectStorage _images;

    private Coroutine _coroutine;
    private WaitForSecondsRealtime _wait;
    private SpriteRenderer _renderer;

    private void Start()
    {
        _wait = new WaitForSecondsRealtime(_shootDealayValue);
        _renderer = GetComponent<SpriteRenderer>();
        _renderer.sprite = _images.GetSprite();
    }

    private void OnEnable()
    {
        if (_coroutine == null)
            _coroutine = StartCoroutine(Shooting());
    }

    private void OnDisable()
    {
        _coroutine = null;
    }

    private IEnumerator Shooting()
    {
        while (enabled)
        {
            _attacker.Attack();
            yield return _wait;
        }

        _coroutine = null;
    }
}
