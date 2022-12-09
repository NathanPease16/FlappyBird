using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncrementScore : MonoBehaviour
{
    /// <summary>
    /// A trigger is similar to a collider, except it doesn't cause a physical
    /// collision, instead acting as a way to see if two colliders intersect
    /// with one another, OnTriggerEnter is called when something enters the
    /// trigger
    ///
    /// Adds 1 to the score when the player enters the trigger
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        // Adds 1 to the score
        other.gameObject.transform.GetComponent<ScoreTracker>().AddToScore(1);
    }
}
