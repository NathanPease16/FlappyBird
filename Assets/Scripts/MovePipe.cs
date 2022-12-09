using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipe : MonoBehaviour
{
    [Header("Attributes")]
            [Tooltip("The speed at which the pipe moves")]
        [SerializeField] private float speed;

    private const float LIMIT = -20;

    /// <summary>
    /// If Update were used here it would call 200 times a second 
    /// if you had 200fps and only 20 times a second if you
    /// had 20fps, meaning the pipes would move faster the
    /// more fps you have, but FixedUpdate is called at
    /// a constant rate independent of frame rate, meaning
    /// it moves at a constant rate across all systems
    ///
    /// Changes the position of the pipes at a constant rate
    ///</summary>
    private void FixedUpdate()
    {
        // Moves the pipe by speed
        Vector3 newPosition = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);

        transform.position = newPosition;
    }

    /// <summary>
    /// Checks if the pipe is offscreen, and if it is
    /// then the pipe is destroyed
    /// </summary>
    private void Update()
    {
        // If the pipe is offscreen, destroy it
        if (transform.position.x <= LIMIT)
            Destroy(transform.gameObject);
    }
}
