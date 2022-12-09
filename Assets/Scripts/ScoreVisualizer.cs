using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreVisualizer : MonoBehaviour
{
    [Header("References")]
            [Tooltip("The ScoreTracker object")]
        [SerializeField] private ScoreTracker birdScore;

    private TextMeshProUGUI scoreText;

    /// <summary>
    /// Assigns the value of scoreText
    /// </summary>
    private void Start()
    {
        // Assigns scoreText to the object this script is on's TextMeshProGUI
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    /// <summary>
    /// Sets the text of scoreText to the current score
    /// </summary>
    private void Update()
    {
        // Sets the text to the score
        scoreText.text = birdScore.GetScore() + "";
    }
}
