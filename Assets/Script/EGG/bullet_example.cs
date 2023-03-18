using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_example :bullet
{
    float AbsSpeed = 1;
    // Start is called before the first frame update
    public void SetDir(float dx, float dy)
    {
        speed.x = dx;
        speed.y = dy;
        speed.Normalize();
        speed *= AbsSpeed;
    }
    public void SetDir(float dx, float dy,float Speed)
    {
        AbsSpeed = Speed;
        speed.x = dx;
        speed.y = dy;
        speed.Normalize();
        speed *= AbsSpeed;
    }
    public void SetSpeed(float speed)
    {
        AbsSpeed = speed;
    }

    protected override void act()
    {
    }

    protected override void init()
    {
    }
}
