using UnityEngine;
using TMPro;

public class UIScoreBoard : MonoBehaviour
{
    public TMP_Text scoreField;
    public TMP_Text multiplierField;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        ScoreManager.OnScoreMultiplierUpdated += UpdateScoreAndMultiplier;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdateScoreAndMultiplier(int score, int multiplier)
    {
        scoreField.text = $"score:\"{score}\"";
        multiplierField.text = $"mult:\"{multiplier}\"";
    }   
}
