using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private LayerMask stageLayer;
    private Rigidbody2D rb;
    private float speed = 10.0f;
    private Vector2 _direction;
    private Vector2 _directionReserve;
    CircleCollider2D circleCol;
    //�����p
    private float xSpeed = 1.0f;
    private float ySpeed = 1.0f;
    //�Ȃ������񐔂��J�E���g�p
    private int counter = 0;
    //�Ȃ��鏈���Ɏ��s������
    private bool isHitWall = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        circleCol = GetComponent<CircleCollider2D>();
    }
    private void Update()
    {
        if(Input.GetAxisRaw("Horizontal") !=0 || Input.GetAxisRaw("Vertical") != 0)
        {
            //���A�E
            _directionReserve.x = Input.GetAxisRaw("Horizontal");
            //��A��
            _directionReserve.y = Input.GetAxisRaw("Vertical");
        }
        if(_directionReserve != Vector2.zero)
        {
            CheckDirection(_directionReserve);
        }
    }
    private void FixedUpdate()
    {
        Vector2 dist = _direction * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + dist);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Map")
        {
            //�ǐڐG��
            Debug.Log("Map Hit");
            circleCol.enabled = true;
            CountTime();
            Debug.Log("Atack!");
            StartCoroutine("WaitTime");
        }
        else
        {
            //�G��e��
            Debug.Log("Enemy Hit");
            circleCol.enabled = false;
            Debug.Log("End2");
        }
    }
    IEnumerator WaitTime()
    {
        //�Ռ��g����
        yield return new WaitForSeconds(1);
        circleCol.enabled = false;
        Debug.Log("End");
    }
    private void CheckDirection(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.BoxCast
            (transform.position, Vector2.one * 0.5f, 0.0f, direction, 1.0f, stageLayer);
        if(hit.collider == null)
        {
            _direction = direction;
            _directionReserve = Vector2.zero;
        }
    }
    private void CountTime()
    {
        float _time = Time.time;
        if(_time <= 1)
        {
            isHitWall = true;
        }
        if(isHitWall == true)
        {
            speed = 1.0f;
            Debug.Log("SpeedReset");
        }
        _time = 0;
    }
}
