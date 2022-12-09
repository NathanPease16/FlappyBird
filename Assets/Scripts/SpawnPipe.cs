using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPipe : MonoBehaviour
{
    [Header("Attributes")]
            [Tooltip("The pipe GameObject to be spawned")]
        [SerializeField] private GameObject pipes;
            [Tooltip("The rate pipes spawn")]
        [SerializeField] private float spawnRate;
            [Tooltip("The min positional offset for pipes to spawn at")]
        [SerializeField] private float minOffset;
            [Tooltip("The max positional offset for pipes to spawn at")]
        [SerializeField] private float maxOffset;

    private float timer;

    /// <summary>
    /// Sets timer equal to spawnRate
    /// </summary>
    private void Start()
    {
        // Makes it so a pipe spawns right away instead of after spawnRate seconds
        timer = spawnRate;
    }

    /// <summary>
    /// Increments a timer by the amount of time passed since
    /// the last frame and spawns a new pipe if enough time has
    /// passed
    /// </summary>
    private void Update()
    {

        // If the timer has reached spawnRate or greater, spawn a new pipe
        if (timer >= spawnRate)
        {
            GameObject pipe = Instantiate(pipes);

            float offset = Random.Range(minOffset, maxOffset);

            // Give it a random offset
            Vector3 newPosition = new Vector3(pipe.transform.position.x, pipe.transform.position.y + offset, pipe.transform.position.z);
            pipe.transform.position = newPosition;

            timer = 0;
        }
        
        // Increment timer by the time since the last frame
        timer += Time.deltaTime;
    }
}
