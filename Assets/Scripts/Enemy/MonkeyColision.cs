using System.Collections;
using UnityEngine;

public class MonkeyColision : MonoBehaviour
{

    private GameManager gameManager = null;
    private Collider2D col = null;
    private SpriteRenderer spriteRenderer = null;
    public int hp = 3;
    public bool isDead = false;
    private bool isDamaged = false;
    private PlayerAttack playerAttack;
    private AllPooler allPooler;

    void Awake()
    {
        if (isDead) return;
        allPooler = GetComponent<AllPooler>();
        playerAttack = FindObjectOfType<PlayerAttack>();
        gameManager = FindObjectOfType<GameManager>();
        col = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead) return;

        if (collision.CompareTag("Stone"))
        {
            collision.GetComponent<BulletMove>().Pooling();

            if (hp >= 1)
            {
                if (isDamaged) return;
                isDamaged = true;
                StartCoroutine(Damaged());
                return;
            }

            isDead = true;
            StartCoroutine(ShowDead());
        }
    }

    private IEnumerator Damaged()
    {
        hp -= playerAttack.attackPower;
        spriteRenderer.material.SetColor("_Color", new Color(0f, 0f, 0f, 0.8f));
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.material.SetColor("_Color", new Color(1f, 1f, 1f, 1f));
        isDamaged = false;
    }

    private IEnumerator ShowDead()
    {
        spriteRenderer.material.SetColor("_Color", new Color(1f, 1f, 1f, 1f));
        col.enabled = false;
        yield return new WaitForSeconds(0.1f);
        col.enabled = true;
        allPooler.DeSpawn();
    }
}