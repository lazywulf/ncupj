using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellcardMannger : MonoBehaviour
{
    public GameObject boss;
    public float time;
    protected void BaseUpdate()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            Debug.Log("over");
        }
    }

}
