using System;
using UnityEngine;

[RequireComponent(typeof(Bat), typeof(Collider2D))]
public class BatCollisionHandler : MonoBehaviour
{
    private Collider2D _collider;

    public event Action<IInteractable> CollisionDetected;

    private void OnValidate()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out IInteractable interactable))
        {
            CollisionDetected?.Invoke(interactable);
        }
    }
}
