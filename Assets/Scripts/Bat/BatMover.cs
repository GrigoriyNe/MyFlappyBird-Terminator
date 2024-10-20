using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BatMover : MonoBehaviour
{
    [SerializeField] private float _tapForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private InputReader _input;
    [SerializeField] private Attacker _attacker;

    private Rigidbody2D _rigidbody2D;
    private Vector3 _startPosition;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;
    private Coroutine _coroutine;
    private WaitForSecondsRealtime _delayAttack;
    private float _delayValue = 1f;

    private void Start()
    {
        _startPosition = transform.position;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _delayAttack = new WaitForSecondsRealtime(_delayValue);

        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
    }

    private void OnEnable()
    {
        _input.IsFlyes += Fly;
        _input.IsAtack += Shoot;
    }

    private void OnDisable()
    {
        _input.IsFlyes -= Fly;
        _input.IsAtack -= Shoot;
    }

    private void Fly(bool isFlyPress)
    {
        if (isFlyPress)
        {
            _rigidbody2D.velocity = new Vector2(_speed, _tapForce);
            transform.rotation = _maxRotation;
        }

        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
        }
    }

    private void Shoot(bool isShoot)
    {
        if (isShoot)
        {
            if (_coroutine == null)
                _coroutine = StartCoroutine(ShootWhithDelay());
        }
    }

    private IEnumerator ShootWhithDelay()
    {
        _attacker.Attack();
        yield return _delayAttack;
        _coroutine = null;
    }

    public void Reset()
    {
        transform.position = _startPosition;
    }
}
