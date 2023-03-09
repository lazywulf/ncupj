using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_example :bullet
{
    float AbsSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        base.BaseStart();//這行一定要加
    }
    void Update()
    {
        base.BaseUpdate();//這行也是
    }
    public void SetDir(float dx, float dy)
    {
        speed.x = dx;
        speed.y = dy;
        speed.Normalize();
        speed *= AbsSpeed;
    }
    public void SetSpeed(float speed)
    {
        AbsSpeed = speed;
    }
}
