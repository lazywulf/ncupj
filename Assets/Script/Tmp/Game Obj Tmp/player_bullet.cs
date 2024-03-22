//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class player_bullet : MonoBehaviour
//{
//    Vector2 speed;
//    // Start is called before the first frame update
//    void Start(){
//        speed = new Vector2(0,5);
//    }
//    private void FixedUpdate()
//    {
        
//    }
//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (collision.CompareTag("enemy"))
//        {
//            collision.gameObject.GetComponent<enemy>().Hit_enemy(1);
//            Debug.Log("hit");
//        }
//    }
//    // Update is called once per frame
//    void Update()
//    {
//        gameObject.transform.Translate(speed * Time.deltaTime);
//        if (transform.position.y > 6)
//        {
//            Destroy(gameObject);
//        }
//    }
//}
