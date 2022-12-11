using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMannger : MonoBehaviour
{
    public List<GameObject> bulletlist ;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject CreateBullet(BulletInfo bul)
    {
        GameObject tar = Instantiate(bullet);
       tar.GetComponent < BulletDisplay >().BulletInfo = bul;
        bulletlist.Add(tar);
        return tar;
    }
}
