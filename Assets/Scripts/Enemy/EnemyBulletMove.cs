using UnityEngine;

public class EnemyBulletMove : BulletMove
{
    private AllPooler allPooler;

    void Start()
    {
        allPooler = GetComponent<AllPooler>();
    }

    protected override void Move()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

    }
    protected override void Domain()
    {
        if (transform.position.x < GameManager.Instance.MinPosition.x)
        {
            allPooler.DeSpawn();
        }
    }
}
