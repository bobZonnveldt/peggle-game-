using UnityEngine;

public class Pegscore : MonoBehaviour
{
    [Header("Instellingen")]
    public int totalHits = 3;       
    public int pointsPerHit = 10;   

    private int hitsRemaining;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        hitsRemaining = totalHits;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       
        Debug.Log($"Peg hit detected: collider={collision.gameObject.name}, tag={collision.gameObject.tag}");
        if (collision.gameObject.CompareTag("Ball"))
        {
            HandleHit();
        }
    }
    

    void HandleHit()
    {
        hitsRemaining--;
        Debug.Log($"HandleHit: hitsRemaining={hitsRemaining}, adding {pointsPerHit} points");
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.AddScore(pointsPerHit);
        }
        else
        {
            Debug.LogWarning("ScoreManager.Instance is null - did you add the ScoreManager to the scene and assign the UI Text?");
        }

        if (spriteRenderer != null)
        {
            float factor = (float)hitsRemaining / totalHits;
            spriteRenderer.color = new Color(factor, factor, factor, 1f);
        }

       
        if (hitsRemaining <= 0)
        {
            Destroy(gameObject);
        }
    }
}
