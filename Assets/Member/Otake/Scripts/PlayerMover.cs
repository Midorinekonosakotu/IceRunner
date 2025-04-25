using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 1.0f;
    private Vector2 direction;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") !=0 || Input.GetAxisRaw("Vertical") != 0)
        {
            //ç∂ÅAâE
            direction.x = Input.GetAxisRaw("Horizontal");

            //è„ÅAâ∫
            direction.y = Input.GetAxisRaw("Vertical");
        }

    }
    private void FixedUpdate()
    {
        Vector2 dist = direction * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + dist);
    }
}
