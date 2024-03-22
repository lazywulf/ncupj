//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public abstract class bullet : MonoBehaviour
//{
//    protected float up_lim=100, down_lim=-100, left_lim=-100, right_lim=100;
//    protected Vector2 now_position,speed;
//    bool need_destroy = false;
//    protected abstract void act();
//    protected abstract void init();
//    protected void OnEnable()
//    {
//        need_destroy = false;
//        speed = new Vector2(0, 0);
//        init();
//    }
//    protected void Update()
//    {
//        act();
//        now_position = gameObject.transform.position;
//        if (now_position.x < -15 || now_position.x > 15)
//        {
//            need_destroy = true;
//        }
//        if (now_position.y > 10 || now_position.y < -10)
//        {
//            need_destroy = true;
//        }
//        gameObject.transform.Translate(speed * Time.deltaTime);
//        if (need_destroy) destroy_this();
//    }
//    void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (collision.gameObject.CompareTag("Player"))
//        {
//            //Debug.Log("-1");
//            //need_destroy = true;
//        }
//    }

//    virtual protected void destroy_this()
//    {
//        Destroy(gameObject);
//    }
//}
