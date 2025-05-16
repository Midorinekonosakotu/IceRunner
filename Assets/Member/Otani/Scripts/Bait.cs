using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bait : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ƒvƒŒƒCƒ„[‚É“–‚½‚Á‚½‚Ìˆ—
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.Score++;
            Destroy(this.gameObject);
        }
    }
}
