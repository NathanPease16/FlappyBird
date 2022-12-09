using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillBird : MonoBehaviour
{
    /// <summary>
    /// OnCollisionEnter calls when two colliders hit each other
    ///
    /// Restarts the game if the player hits a pipe
    /// </summary>
    void OnCollisionEnter(Collision other)
    {
        // If the thing that entered is the player, call the kill method in the Movement class
        if (other.transform.tag == "Player")
            other.transform.GetComponent<Movement>().Kill();
    }
}
