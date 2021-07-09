using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletMove: MonoBehaviour
{
    [SerializeField]
    private float speed = 30f;

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime, Space.Self);
        if (transform.position.x < GameManager.Instance.MinPosition.x)
        {
            Destroy(gameObject);
        }
        if (transform.position.y < GameManager.Instance.MinPosition.y)
        {
            Destroy(gameObject);
        }
    }
}

