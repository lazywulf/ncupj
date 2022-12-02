using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_mannger : MonoBehaviour
{
    public InputManager InputManager;
    public bool isdown, isup, isleft, isright, isslow;
    private Rigidbody2D rb;
    public Vector2 speed;
    public GameObject bul;
    private float abs_speed,high_speed = 1,low_speed = 0.707f,slow_mode_mut;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isdown = false;
        isup = false;
        isleft = false;
        isright = false;
        isslow = false;
        speed = new Vector2(0, 0);
        slow_mode_mut = 1;
    }

    private void FixedUpdate()
    {
        cacmove();

    }
    // Update is called once per frame
    void Update()
    {
        if (InputManager.Fire())
        {
            Instantiate(bul, transform.position,new Quaternion(0,0,0,0));
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy")) Debug.Log("col");
    }
    void cacmove()
    {
        /*
        if (InputManager.Down()) isdown = true;
        else isdown = false;
        if (InputManager.Up()) isup = true;
        else isup = false;
        if (InputManager.Left()) isleft = true;
        else isleft = false;
        if (InputManager.Right()) isright = true;
        else isright = false;
        if (InputManager.Slow()) isslow = true;
        else isslow = false;
        */
        if (isdown ^ isup && isright ^ isleft) abs_speed = low_speed;
        else abs_speed = high_speed;
        if (isleft) speed.x = -abs_speed * slow_mode_mut;
        else if (isright) speed.x = abs_speed * slow_mode_mut;
        else speed.x = 0;
        if (isup) speed.y = abs_speed * slow_mode_mut;
        else if (isdown) speed.y = -abs_speed * slow_mode_mut;
        else speed.y = 0;
        rb.velocity=speed;
        
    }
}
