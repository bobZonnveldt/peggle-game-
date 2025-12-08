using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public TextMeshProUGUI scoreText;

    private int score = 0;

    void Awake()
    {
        Debug.Log($"ScoreManager.Awake: Instance present? {Instance != null}");
        if (Instance != null && Instance != this)
        {
            Debug.Log("ScoreManager.Awake: duplicate found - destroying duplicate component, not GameObject");
            Destroy(this);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        Debug.Log($"ScoreManager.Awake: set Instance={name}");
    }

    void Start()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: 0";
        }
        else
        {
            Debug.LogWarning("ScoreManager.Start: scoreText is not assigned (null). Assign a TextMeshProUGUI in the Inspector.");
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log($"ScoreManager.AddScore: +{amount} -> total={score}");
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
