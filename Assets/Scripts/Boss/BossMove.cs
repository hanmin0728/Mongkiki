using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    private Vector2 dir = Vector2.down;
    void Start()
    {
        StartCoroutine(SpeedChange());
    }

    void Update()
    {
        EnemyMovkeyMove();
    }

    private IEnumerator SpeedChange()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(5f, 15f));
            speed = Random.Range(3f, 10f);
        }
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
