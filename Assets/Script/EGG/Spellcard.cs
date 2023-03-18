using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpellcardMannger : MonoBehaviour
{
    public GameObject boss;
    protected enemy boss_sc;
    protected int hp;
    public float time;

    [SerializeField] private GameEvent @event;
    protected abstract void init();
    protected abstract void clear();
    protected abstract void act();
    public void InitSpellCard() {
        //boss = GameObject.Find("boss");
        boss_sc = boss.GetComponent<enemy>();
        init();
    }
    protected void DestroySpellCard()
    {
        clear();
        @event.Raise();
    }


    void Update()
    {
        act();
        time -= Time.deltaTime;
        hp = boss_sc.GetHp();
        if (time < 0)
        {
            Debug.Log("over");
        }
        if (hp < 0)
        {
            Debug.Log("hp=0");
            //Destroy(boss);
        }
    }
    public float GetTime() { return time; }
    public int GetHp() { return hp; }


}
