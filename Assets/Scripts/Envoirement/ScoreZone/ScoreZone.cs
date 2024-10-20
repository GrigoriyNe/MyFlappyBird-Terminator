using UnityEngine;

public class ScoreZone : SpawnerableObject, IInteractable
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
