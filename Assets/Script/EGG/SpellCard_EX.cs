using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCard_EX : SpellcardMannger
{
    float time,shoot_time=1;
    public GameObject line_bul,player;
    Vector2 dir;
    /// <summary>
    /// need to be delete
    /// use for test
    /// </summary>
    private void Start()
    {
        InitSpellCard();
        player = GameObject.Find("Player");
        
    }
    //Start
    protected override void init()
    {
        time = 0;
        dir = new Vector2(0, 0);
        SC_Time = 40;
    }
    //Update
    protected override void act()
    {
        time += Time.deltaTime;
        if (time > shoot_time)
        {
            GameObject bul;
            dir = player.gameObject.transform.position - boss.gameObject.transform.position;
            bul = Instantiate(line_bul,boss.gameObject.transform.position,Quaternion.identity);
            bul.GetComponent<bullet_example>().SetDir(dir.x,dir.y,10);
            time = 0;
        }
    }
    protected override void clear(){}
}
