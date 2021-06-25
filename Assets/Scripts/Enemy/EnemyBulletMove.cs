using UnityEngine;

public class EnemyBulletMove : BulletMove
{
    private AllPooler allPooler;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        allPooler = GetComponent<AllPooler>();
    }

    protected override void Move()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

    }
    protected override void Domain()
    {
        if (transform.position.x < gameManager.MinPosition.x)
        {
            allPooler.DeSpawn();
        }
    }
}
