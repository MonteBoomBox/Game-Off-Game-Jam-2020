using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float movement = 0f;

    public float rotateSpeed = 150f;

    Rigidbody2D rb;

    public float boost = 200f;

    private Vector2 ScreenBounds;

    private bool isAlive;

    public float DestroyDelay = 0.2f;


    void Start()
    {
        isAlive = true;
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
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

    public void OnBecameInvisible()
    {
        isAlive = false;
        Destroy(gameObject, DestroyDelay);
    }
}
