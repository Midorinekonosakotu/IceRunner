using System.Collections;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private LayerMask stageLayer;
    [SerializeField] private GameObject shockWave;
    [SerializeField] private Transform attackCircle;
    public SceneLoader _sceneLoder;
    private Rigidbody2D rb;
    private float speed = 7.0f;
    private Vector2 _direction;
    private Vector2 _directionReserve;
    //加速用
    private float xSpeed = 1.0f;
    private float ySpeed = 1.0f;
    //曲がった回数をカウント用
    private int counter = 0;
    //曲がる処理に失敗した時
    private bool isHitWall = false;

    private bool hori = false;
    private bool vart = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        shockWave.SetActive(false);
    }
    private void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            //左、右
            _directionReserve.x = Input.GetAxisRaw("Horizontal");
            //上、下
            _directionReserve.y = Input.GetAxisRaw("Vertical");
        }
        if (_directionReserve != Vector2.zero)
        {
            CheckDirection(_directionReserve);
        }
        //衝撃波の範囲を速度に応じて拡大
        attackCircle.localScale = Vector3.one * (1.0f + speed / 3.0f);
        Vector2 dist = _direction * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + dist);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Map")
        {
            //壁接触時
            Debug.Log("Map Hit");
            if (speed >= 12.0f)
            {
                shockWave.SetActive(true);
                Debug.Log("Atack!");
            }
            CountTime();
            StartCoroutine("WaitTime");
        }
        if (collision.gameObject.tag == "Enemy")
        {
            //敵被弾時
            Debug.Log("Enemy Hit");
            Debug.Log("End2");
        }

    }

    IEnumerator WaitTime()
    {
        //衝撃波持続
        yield return new WaitForSeconds(1);
        shockWave.SetActive(false);
        Debug.Log("End");
    }
    private void CheckDirection(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.BoxCast
            (transform.position, Vector2.one * 0.5f, 0.0f, direction, 1.0f, stageLayer);
        if (hit.collider == null)
        {
            _directionReserve = Vector2.zero;
            if ((direction.x == 0 && direction.y == 0) == false)
            {
                if(_direction != direction)
                {
                    speed += 0.2f;
                    //加速
                    Debug.Log("kasoku");
                }
            }
            _direction = direction;
        }
    }
    private void CountTime()
    {
        float _time = Time.time;
        if (_time <= 1)
        {
            isHitWall = true;
        }
        if (isHitWall == true)
        {
            //speed = 1.0f;
            Debug.Log("SpeedReset");
        }
        _time = 0;
    }

}
