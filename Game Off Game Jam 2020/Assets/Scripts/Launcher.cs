using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public float moveSpeed = 200f;

    private float movement = 0f;

    public float launchSpeed = 5f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        LauncherMovement();
        movement = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    public void LauncherMovement()
    {
        Vector2 CannonPos = transform.position;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - CannonPos;
        transform.right = direction;
    }

    public void Shoot()
    {
        GameObject Rocket = GameObject.FindGameObjectWithTag("Rocket");
        Rigidbody2D rb = Rocket.GetComponent<Rigidbody2D>();
        Rocket.transform.parent = null;
        rb.isKinematic = false;
        rb.velocity = transform.up * launchSpeed;
        gameObject.GetComponent<Launcher>().enabled = false;
    }
}
