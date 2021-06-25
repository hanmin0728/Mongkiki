using System.Collections;
using UnityEngine;

public class BeeHouseEnemyMove : MonoBehaviour
{

    protected SpriteRenderer spriteRenderer = null;
    protected Collider2D col = null;
    private PlayerAttack playerAttack;
    protected AllPooler allPooler;
    protected GameManager gameManager;
    protected GameObject newbee;
    public bool isDead = false;
    public bool isDamaded = false;

    public int hp = 2;
    [SerializeField]
    protected float speed = 6f;
    private int score1 = 30;

    private void Start()
    {
        if (isDead) return;
        gameManager = FindObjectOfType<GameManager>();
        allPooler = GetComponent<AllPooler>();
        playerAttack = FindObjectOfType<PlayerAttack>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }

    protected virtual void Update()
    {
        Move();
        DoMain();
    }
    protected virtual void Move()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    protected void DoMain()
    {
        if (transform.position.x < gameManager.MinPosition.x)
        {
            allPooler.DeSpawn();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead) return;
        if (collision.CompareTag("Stone"))
        {
            if (collision.GetComponent<BulletMove>() != null)
            {
                collision.GetComponent<BulletMove>().Pooling();
            }

            if (hp >= 1)
            {
                if (isDamaded) return;
                isDamaded = true;
                StartCoroutine(Damaged());
                if (hp <= 0)
                {
                    isDead = true;
                    StartCoroutine(ShowDead());
                }
                return;
            }
        }
    }

    private IEnumerator Damaged()
    {
        hp -= playerAttack.attackPower;
        spriteRenderer.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.material.color = Color.white;
        isDamaded = false;
    }

    protected virtual IEnumerator ShowDead() // 애니메이션을 처리해주는 데드
    {
        StartCoroutine(CreateBee());
        spriteRenderer.material.SetColor("_Color", new Color(1f, 1f, 1f, 0f));
        col.enabled = false;
        yield return new WaitForSeconds(0.2f);
        col.enabled = true;
        spriteRenderer.material.SetColor("_Color", new Color(1f, 1f, 1f, 1f));
        allPooler.DeSpawn();
        gameManager.AddScore(score1);
    }

    private IEnumerator CreateBee()
    {
        for (int i = 0; i < 2; i++)
        {
            newbee = gameManager.allPoolManager.GetPool(3);
            newbee.transform.position = transform.position + new Vector3(Random.Range(-0.8f, 0.8f), Random.Range(-0.8f, 0.8f), 0f);
            newbee.GetComponent<BeeEnemyMove>().isDead = false;
            newbee.GetComponent<BeeEnemyMove>().isDamaded = false;
            newbee.GetComponent<BeeEnemyMove>().hp = 2;
            newbee.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.1f);
        }

    }

}
