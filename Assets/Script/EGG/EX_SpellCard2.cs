using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EX_SpellCard2 : Spellcard
{
    int cnt = 10;
    float time = 1.3f,nt;
    public GameObject bul;
    GameObject nbu;
    Vector3 bosspos;
    protected override void act()
    {
        nt += Time.deltaTime;
        bosspos = boss.gameObject.transform.position;
        if (nt > time) {
            nt = 0;
            for(int i = 0; i < cnt; i++){
                nbu = Instantiate(bul, bosspos, Quaternion.identity);
                Vector2 tar;
                tar = r_and_angle(250, (float)(i * Mathf.PI / 180 * (360/cnt) + Mathf.PI / 2),bosspos);
                nbu.GetComponent<bullet_example>().SetDir(tar.x, tar.y, 10);
            }
        }
    }

    protected override void clear(){}

    protected override void init()
    {
        
    }

    private void Start()
    {
        InitSpellCard();

    }
}
