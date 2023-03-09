using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellcardMannger : MonoBehaviour
{
    public GameObject boss;
    protected enemy boss_sc;
    protected int hp;
    public float time;
    protected void BaseStart()
    {
        boss_sc = boss.GetComponent<enemy>();
    }

    protected void BaseUpdate()
    {
        time -= Time.deltaTime;
        hp = boss_sc.GetHp();
        if (time < 0)
        {
            Debug.Log("over");
        }
        if (hp < 0)
        {
            Debug.Log("hp=0");
            Destroy(boss);
        }
    }

    public float GetTime() { return time; }
    public int GetHp() { return hp; }


}
