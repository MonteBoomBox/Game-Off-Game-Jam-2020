using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float movement = 0f;

    public float rotateSpeed = 150f;

    Rigidbody2D rb;

    public float boost = 200f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;        
    }

    // Update is called once per frame
    void Update()
    {

        movement = Input.GetAxisRaw("Horizontal");

        if (Input.GetKey(KeyCode.Space))
        {
            ApplyThrust();
        }
    }

    public void ApplyThrust()
    {
        rb.AddRelativeForce(Vector3.up * boost * Time.deltaTime);
    }

    public void FixedUpdate()
    {
        transform.RotateAround(transform.position, Vector3.forward, movement * Time.fixedDeltaTime * -rotateSpeed);
    }
}
