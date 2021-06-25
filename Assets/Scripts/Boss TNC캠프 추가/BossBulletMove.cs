using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletMove : BulletMove
{

    protected override void Move()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    protected override void Domain()
    {
        if (transform.position.y > gameManager.MinPosition.y)
        {
            Destroy(gameObject);
        }
        if (transform.position.y > gameManager.MaxPosition.y)
        {
            Destroy(gameObject);

        }
        if (transform.position.x < gameManager.MinPosition.x)
        {
            Destroy(gameObject);
        }
        if (transform.position.x > gameManager.MaxPosition.x)
        {
            Destroy(gameObject);
        }
    }
}
