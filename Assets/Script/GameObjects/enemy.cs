using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int hp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetHp()
    {
        return hp;
    }

    public void Hit_enemy(int point)
    {
        hp -= point;
    }
}
