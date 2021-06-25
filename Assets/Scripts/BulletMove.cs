using UnityEngine;

public class BulletMove : MonoBehaviour
{
    protected GameManager gameManager = null;
    [SerializeField]
    protected float speed = 10f;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        Move();
        Domain();
    }

    protected virtual void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    protected virtual void Domain()
    {
        if (transform.localPosition.x > gameManager.MaxPosition.x + 3f)
        {
            Pooling();
        }
    }

    public void Pooling()
    {
        transform.SetParent(gameManager.poolManager.transform);
        gameObject.SetActive(false);
    }
}
