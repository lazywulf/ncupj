using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_mannger : MonoBehaviour
{
    protected Rigidbody2D rb;
    Vector2 speed;
    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        speed = new Vector2(0,5);
        rb.velocity = speed;
    }
    private void FixedUpdate()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy")) Debug.Log("hit");
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 6)
        {
            Destroy(gameObject);
        }
    }
}
