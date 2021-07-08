using UnityEngine;

public class BulletMove : MonoBehaviour
{

    [SerializeField]
    protected float speed = 10f;

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
        if (transform.localPosition.x > GameManager.Instance.MaxPosition.x + 3f)
        {
            Pooling();
        }
    }

    public void Pooling()
    {
        transform.SetParent(GameManager.Instance.PoolManager.transform);
        gameObject.SetActive(false);
    }
}
