using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{   
    [Header("Attributes")]
            [Tooltip("The number of pipes the player has made it through")]
        [SerializeField] private int score;

    /// <summary>
    /// Adds to the value of the score
    /// </summary>
    /// <param name="_score">The amount to be added</param>
    public void AddToScore(int _score)
    {
        score += _score;
    }

    /// <summary>
    /// Gets the current score
    /// </summary>
    ///<returns>The current score</returns>
    public int GetScore()
    {
        return score;
    }
}
