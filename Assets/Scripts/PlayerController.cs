using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }
    private Rigidbody rb;
    private float moveH;
    private float brake;

    // Brake force
    public float brakeForce = 10f;

    // Player HP
    public int healthPoints = 5;

    // Player horizontal speed
    public float horizontalSpeed = 10f;

    // Player movement forward speed
    public float forwardSpeed = 20;
    public float speedCorrectionRatio = 3000f;
    public float brakeCorrectionRatio = 1f;
    public float spawningCorrectionRatio = 0.001f;
    [HideInInspector]
    public float forwardMovement;
    [HideInInspector]
    public float spawningCooldown;

    // Resource counter
    [HideInInspector]
    public float coinCounter = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        // Instatiate PlayerController
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void FixedUpdate()
    {
        // Ensure game is active
        if (!GameManager.Instance.isGameActive)
        {
            return;
        }

        // Cooldown by movement
        spawningCooldown = (forwardSpeed + (rb.velocity.z * brakeCorrectionRatio)) * spawningCorrectionRatio;

        // Continuous forward player movement
        Vector3 forwardMove = transform.forward * forwardSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove);
        forwardMovement = (forwardSpeed + (rb.velocity.z * brakeCorrectionRatio)) * speedCorrectionRatio;

        // Player movement
        movePlayer();
    }

    void movePlayer()
    {
        moveH = Input.GetAxis("Horizontal");
        brake = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(moveH * horizontalSpeed, rb.velocity.y, brake * brakeForce);

        // Limit player boundaries
        float movementLimit = 4;
        if (transform.position.x <= -movementLimit)
        {
            transform.position = new Vector3(-movementLimit, transform.position.y, transform.position.z + (Time.fixedDeltaTime * forwardSpeed));
        }
        else if (transform.position.x >= movementLimit)
        {
            transform.position = new Vector3(movementLimit, transform.position.y, transform.position.z + (Time.fixedDeltaTime * forwardSpeed));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Zombie")
        {
            Destroy(other.gameObject);
            healthPoints--;
        }
        if (other.gameObject.tag == "Health")
        {
            Destroy(other.gameObject);
            if (healthPoints >= 5)
            {

            }
            else
            {
                healthPoints++;
            }
        }
        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            coinCounter++;
        }
        if (other.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("Game");
        }
    }
}
