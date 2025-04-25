using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 1.0f;
    private Vector2 direction;
    CircleCollider2D circleCol;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        circleCol = GetComponent<CircleCollider2D>();
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Map")
        {
            Debug.Log("Map Hit");
            circleCol.enabled = true;
            Debug.Log("Atack!");
            StartCoroutine("WaitTime");

        }
        else
        {
            Debug.Log("Enemy Hit");
            circleCol.enabled = false;
            Debug.Log("End2");
        }
    }
    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(1);
        circleCol.enabled = false;
        Debug.Log("End");
    }
}
