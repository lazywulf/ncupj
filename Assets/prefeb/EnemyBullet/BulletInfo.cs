using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewBullet", menuName = "CreateSO/Create Enemy Bullet")]
public class BulletInfo : ScriptableObject
{
    public Vector2 pos = new Vector2(0, 0);
    bool usespeed = true;
    Vector2 speed = new Vector2(-10, 0);
    public void init(Vector2 initpos)
    {
        pos = initpos;
    }
    public Vector2 nowposition()
    {
        Vector2 tarpos;
        if (usespeed) tarpos = speedpos();
        else tarpos = new Vector2(10, 0);
        pos = tarpos;
        Debug.Log(pos);
        return tarpos;
    }
    private Vector2 speedpos()
    {
        Vector2 tarpos = pos;
        tarpos.x += speed.x * Time.deltaTime;
        tarpos.y += speed.y * Time.deltaTime;
        return tarpos;
    }
}
