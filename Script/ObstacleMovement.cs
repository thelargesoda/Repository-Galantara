using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ObstacleMovement : MonoBehaviour
{
    public float speed = 5f;
    private int direction = 1;
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(direction * speed, rb.velocity.y, rb.velocity.z);
    }

    public void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.CompareTag("Barrier"))
        {
            direction *= -1; 
        }
    }
}

