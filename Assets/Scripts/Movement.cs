using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [Header("References")]
            [Tooltip("The rigidbody of the GameObject the Movement class is on")]
        [SerializeField] private Rigidbody rb;

    [Header("Attributes")]
            [Tooltip("The force applied when flapping upwards")]
        [SerializeField] private float force;
            [Tooltip("The maximum force that can be exerted")]
        [SerializeField] private float maxForce;
            [Tooltip("Limits how quickly the player can flap")]
        [SerializeField] private float flapRateLimit;
            [Tooltip("How much the bird rotates in relation to velocity")]
        [SerializeField] private float rotationAmount;
            [Tooltip("The speed of the rotation linear interpolation")]
        [SerializeField] private float speed;

    private const float OFFSET = -90;
    private float timeCount = 0.0f;
    private float flapTimeCount;

    /// <summary>
    /// This method gets called when the script is first enabled
    /// and assigns rb to this GameObject's Rigidbody component
    /// </summary>
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// This method calls every frame, it handles calling methods
    /// like the Move method and Kill method, and also applies rotation
    /// to the bird according to velocity
    /// </summary>
    private void Update()
    {
        // If the player is pressing space and can flap call move
        if (Input.GetKeyDown(KeyCode.Space) && flapTimeCount >= flapRateLimit)
            Move();

        // Kill the player if they get too low
        if (transform.position.y <= -7)
            Kill();

        // Don't worry about this stuff, it just handles the rotation of the bird in relation to velocity
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(Rotation(), OFFSET, 0), timeCount * speed);
        
        timeCount += Time.deltaTime;
        timeCount = timeCount >= 1 / speed ? 0.0f: timeCount;

        // Increments flapTimeCount by the time that has passed since the last frame
        flapTimeCount += Time.deltaTime;
    }

    /// <summary>
    /// Moves the bird by applying an upward velocity force to the 
    /// GameObject's Rigidbody component
    /// </summary>
    public void Move()
    {   
        // Calculates the upward force by doing (0, 1, 0) * force
        Vector3 addedForce = Vector3.up * force;

        // Applies the upward force to the rigidbody
        rb.AddForce(addedForce, ForceMode.Impulse);

        // If velocity is over maxForce, clamp it to maxForce
        if (rb.velocity.y > maxForce)
            rb.velocity = Vector3.up * maxForce;

        flapTimeCount = 0;
    }

    /// <summary>
    /// Calculates the amount the bird should rotate according to
    /// the current velocity of the bird
    /// </summary>
    /// <returns>The calculated rotational value</returns>
    private float Rotation()
    {
        // More rotation stuff to not worry about
        float magnitude = rb.velocity.y;

        float rotation = ((magnitude / maxForce) * rotationAmount) + OFFSET;

        return rotation;
    }

    /// <summary>
    /// Kills the bird by restarting the scene
    /// </summary>
    public void Kill()
    {
        // Loads the current scene, feel free to modify to fit your neural network
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
