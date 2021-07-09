using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMonkeyMove : MonoBehaviour
{
    [SerializeField]
    private float speed =  5f;

    private Vector2 dir = Vector2.down;
    void Start()
    {
        
    }

    void Update()
    {
        EnemyMovkeyMove();
    }

    private void EnemyMovkeyMove()
    {
        transform.Translate(dir * speed * Time.deltaTime);
        if (transform.position.y <= -3.7f)
        {
            dir = Vector2.up;
        }
        else if (transform.position.y >= 3.7f)
        {
            dir = Vector2.down;
        }
    }
}
