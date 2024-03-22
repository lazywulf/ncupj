//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class player : MonoBehaviour
//{
//	public GenericGameEvent gameover;
//	InputManager Input;
//	public bool isdown, isup, isleft, isright, isslow;
//	public Vector2 speed;
//	public GameObject bul;
//	int hp = 2;
//	private float abs_speed, high_speed = 1, low_speed = 0.707f, slow_mode_mut;
//	// Start is called before the first frame update
//	void Start()
//	{
//		isdown = false;
//		isup = false;
//		isleft = false;
//		isright = false;
//		isslow = false;
//		speed = new Vector2(0, 0);
//		slow_mode_mut = 1;
//		Input = InputManager.instance;
//	}

//	private void FixedUpdate()
//	{
//		cacmove();
//		//if (Input.Down()) {
//		//Debug.Log("h");
//		//}

//	}
//	// Update is called once per frame
//	void Update()
//	{
//		if (Input.Fire())
//		{
//			Instantiate(bul, transform.position, new Quaternion(0, 0, 0, 0));
//		}
//		if (hp <= 0)
//		{
//			gameover.Raise();
//		}
//	}
//	private void OnTriggerEnter2D(Collider2D collision)
//	{
//		if (collision.gameObject.CompareTag("enemy"))
//		{
//			hp--;
//			//Debug.Log("col");
//			//Debug.Log(hp);
//		}
//	}
//	void cacmove()
//	{

//		isdown = Input.Down();
//		isup = Input.Up();
//		isleft = Input.Left();
//		isright = Input.Right();
//		isslow = Input.Slow();

//		if (isslow) slow_mode_mut = low_speed;
//		else slow_mode_mut = high_speed;
//		if (isdown || isup && isright || isleft) abs_speed = low_speed;
//		else abs_speed = high_speed;
//		if (isleft) speed.x = -abs_speed * slow_mode_mut;
//		else if (isright) speed.x = abs_speed * slow_mode_mut;
//		else speed.x = 0;
//		if (isup) speed.y = abs_speed * slow_mode_mut;
//		else if (isdown) speed.y = -abs_speed * slow_mode_mut;
//		else speed.y = 0;
//		gameObject.transform.Translate(speed * Time.deltaTime);
//	}
//}
