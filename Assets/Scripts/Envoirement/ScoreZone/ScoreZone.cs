using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class ScoreZone : SpawnerableObject, IInteractable
{
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TryGetComponent(out SpawnerableObject score);
        Return(score);
    }
}
