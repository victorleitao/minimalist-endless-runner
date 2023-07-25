using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPMovement : MonoBehaviour
{
    // Speed of HP pickup rotation
    public float rotationSpeed = 150f;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // HP Pickup rotation
        transform.Rotate(rotationSpeed * Time.fixedDeltaTime, 0, 0);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}