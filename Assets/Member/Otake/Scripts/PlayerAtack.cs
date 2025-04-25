using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtack : MonoBehaviour
{
    CircleCollider2D  circleCol;
    // Start is called before the first frame update
    void Start()
    {
        circleCol = GetComponent<CircleCollider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Map")
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
    // Update is called once per frame
    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(1);
        circleCol.enabled = false;
        Debug.Log("End");
    }
}
