using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossColison : MonoBehaviour
{
    private bool isDead = false;
    private bool isDamaded = false;
    private SpriteRenderer spriteRenderer;
    private PlayerAttack playerAttack;
    private Collider2D col;
    [SerializeField]
    private int hp = 60;
    private int score3 = 450;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerAttack = FindObjectOfType<PlayerAttack>();
        col = GetComponent<Collider2D>();
    }
    void Update()
    {
        
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

            if (hp > 1)
            {
                if (isDamaded) return;
                isDamaded = true;
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
        spriteRenderer.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.material.color = Color.white;
        isDamaded = false;
    }

    protected virtual IEnumerator ShowDead() // 애니메이션을 처리해주는 데드
    {
        spriteRenderer.material.SetColor("_Color", new Color(1f, 1f, 1f, 0f));
        col.enabled = false;
        yield return new WaitForSeconds(0.2f);
        col.enabled = true;
        spriteRenderer.material.SetColor("_Color", new Color(1f, 1f, 1f, 1f));
        Destroy(gameObject);
        gameManager.AddScore(score3);
    }
}
