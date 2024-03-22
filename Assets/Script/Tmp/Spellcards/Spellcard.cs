//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public abstract class Spellcard : MonoBehaviour
//{
//	public GameObject boss;
//	protected enemy boss_sc;
//	protected int hp;
//	public float SC_Time;

//	private GameEvent @event;

//	protected Vector3 r_and_angle(float r, float angle, Vector3 pos)
//	{
//		float dx = (float)(r * Mathf.Cos(angle));
//		float dy = (float)(r * Mathf.Sin(angle));
//		return new Vector3(pos.x + dx, pos.y + dy);
//	}
//	protected abstract void init();
//	protected abstract void clear();
//	protected abstract void act();
//	public void InitSpellCard()
//	{
//		boss = GameObject.Find("boss");//need to be delete on merge
//		boss_sc = boss.GetComponent<enemy>();
//		init();
//	}
//	protected void DestroySpellCard()
//	{
//		clear();
//		@event.Raise();
//	}


//	void Update()
//	{
//		act();
//		SC_Time -= Time.deltaTime;
//		hp = boss_sc.GetHp();
//		if (SC_Time < 0)
//		{
//			Debug.Log("over");
//		}
//		if (hp < 0)
//		{
//			Debug.Log("hp=0");
//			//Destroy(boss);
//		}
//	}
//	public float GetTime() { return SC_Time; }
//	//public int GetHp() { return hp; }


//}
