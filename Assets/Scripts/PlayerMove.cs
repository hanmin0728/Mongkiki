using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Vector2 targetPosition = Vector2.zero;
    private GameManager gameManager = null;
    public float speed = 30f;
    private bool isDead = false;
    private PlayerAttack playerAttack;
    private SpriteRenderer spriteRenderer = null;

    void Start()
    {
        playerAttack = GetComponent<PlayerAttack>();
        gameManager = FindObjectOfType<GameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (Input.GetMouseButton(0) == true)
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.x = Mathf.Clamp(targetPosition.x, gameManager.MinPosition.x, gameManager.MaxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, gameManager.MinPosition.y, gameManager.MaxPosition.y);
            transform.localPosition = Vector2.MoveTowards(transform.localPosition, targetPosition, speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            playerAttack.state = collision.GetComponent<ItemColision>().index;
            return;
        }
        if (isDead) return;
        isDead = true;
        StartCoroutine(PlayerDead());
    }

    public void StartResetSpeed()
    {
        StartCoroutine(ResetSpeed());
    }

    private IEnumerator ResetSpeed()
    {
        yield return new WaitForSeconds(3f);
        speed = 30;
    }

    private IEnumerator PlayerDead()
    {
        gameManager.Dead();
        for (int i = 0; i < 5; i++)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.2f);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.2f);
        }
        isDead = false;
    }
}
