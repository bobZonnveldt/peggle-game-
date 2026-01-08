using UnityEngine;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public TextMeshProUGUI scoreText;

    private int score = 0;
    private string currentComboColor = null;
    private int comboCount = 0;

    
    public static event Action<int, int> OnScoreMultiplierUpdated;

    void Awake()
    {
      

        Instance = this;
        DontDestroyOnLoad(gameObject);
       
    }

    void Start()
    {
        if (scoreText != null)
        {
            scoreText.text = "score:\"0\" mult:\"1\"";
        }
      
    }

    public void AddScore(int amount)
    {
        AddScore(amount, null);
    }

   
    public void AddScore(int amount, string pegTag)
    {
        string pegColor = null;
        if (!string.IsNullOrEmpty(pegTag))
        {
            if (pegTag.StartsWith("Peg "))
                pegColor = pegTag.Substring(4).Trim();
            else if (pegTag.StartsWith("Peg"))
                pegColor = pegTag.Substring(3).Trim();
            else
                pegColor = pegTag;
        }

        if (!string.IsNullOrEmpty(pegColor))
        {
            if (pegColor == currentComboColor)
            {
                comboCount++;
            }
            else
            {
                currentComboColor = pegColor;
                comboCount = 1;
            }
        }
        else
        {
            
            currentComboColor = null;
            comboCount = 0;
        }

        int pointsToAdd = amount * Mathf.Max(1, comboCount);
        score += pointsToAdd;
        Debug.Log($" begin={amount}, pegkleur={pegColor}, combo={comboCount}, toegevoegd={pointsToAdd} -> totaal={score}");

        // Stuur bericht met huidige score en multiplier
        int multiplier = Mathf.Max(1, comboCount);
        OnScoreMultiplierUpdated?.Invoke(score, multiplier);

        if (scoreText != null)
        {
            scoreText.text = $"score:\"{score}\" mult:\"{multiplier}\"";
        }
      
    }

 
    public void ResetCombo()
    {
        currentComboColor = null;
        comboCount = 0;
        
        // Stuur bericht met huidige score en gereset multiplier
        OnScoreMultiplierUpdated?.Invoke(score, 1);
        
        if (scoreText != null)
        {
            scoreText.text = $"score:\"{score}\" mult:\"1\"";
        }
    }
}
