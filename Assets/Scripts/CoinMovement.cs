using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    // Speed of coin rotation
    public float rotationSpeed = 150f;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Coin rotation
        transform.Rotate(rotationSpeed * Time.fixedDeltaTime, 0, 0);

        // Coin movement towards screen
        //transform.Translate(Vector3.up * coinSpeed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
