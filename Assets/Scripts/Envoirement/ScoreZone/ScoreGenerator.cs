public class ScoreGenerator : ObjectGenerator<ScoreZone>
{
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.TryGetComponent(out Bat _))
            gameObject.SetActive(false);
    }
}
