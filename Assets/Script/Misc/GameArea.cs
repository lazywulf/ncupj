using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameArea : Singleton<GameArea>
{
    float minX;
    float minY;
    float maxX;
    float maxY;

    [SerializeField] private Vector2 spawnPoint;
    
    [field: SerializeField] public Vector2 Padding { get; set; } = new Vector2(0.5f, 0.5f);
    public Vector2 SpawnPoint
    {
        get 
        {
            Vector2 position;
            position.x = transform.position.x + transform.localScale.x * (spawnPoint.x / 2);
            position.y = transform.position.y + transform.localScale.y * (spawnPoint.y / 2);
            return position;
        }
	}
    public Vector2 Center
    {
        get { return transform.position;  }
	}

    private void Start()
    {
        minX = transform.position.x - transform.localScale.x / 2;
        minY = transform.position.y - transform.localScale.y / 2;
        maxX = transform.position.x + transform.localScale.x / 2;
        maxY = transform.position.y + transform.localScale.y / 2;
    }

    public Vector2 MoveablePosition(Vector2 pos)
    {
        Vector2 position = Vector2.zero;
        position.x = Mathf.Clamp(pos.x, minX, maxX);
        position.y = Mathf.Clamp(pos.y, minY, maxY);
        return position;
	}


    public void InBoundChecker(GameObject @object)
    {
        StartCoroutine(BoundaryMonitorCoroutine(@object));
	}

    private IEnumerator BoundaryMonitorCoroutine(GameObject @object)
    {
        while (true)
        {
            Vector2 pos = @object.transform.position;
            if (pos.x > maxX + Padding.x || pos.x < minX - Padding.x
                || pos.y > maxY + Padding.y || pos.y < minY - Padding.y)
                @object.SetActive(false);
            yield return null;
        }
	}
}
