using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField] bool destoryObject = true;
    [SerializeField] float lifetime = 20f;
    WaitForSeconds wait;

    private void OnEnable()
    {
        if (lifetime > 0)
           StartCoroutine(AutoDestroyCoroutine());
	}

    private IEnumerator AutoDestroyCoroutine()
    {
        yield return new WaitForSeconds(lifetime);

        if (destoryObject) Destroy(gameObject);
        else gameObject.SetActive(false);
    }

    public void Destroy()
    {
        if (lifetime <= 0)
        {
            if (destoryObject) Destroy(gameObject);
            else gameObject.SetActive(false);
        }
    }
}
