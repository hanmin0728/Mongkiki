using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    protected GameManager gameManager = null;
    [SerializeField]
    protected float firerate = 2f;
    protected float timer = 0f;
    [SerializeField]
    protected GameObject enemyBulletPrefab = null;
    protected GameObject newbullet = null;
    protected Vector2 diff = Vector2.zero;
    protected float rotaitionZ = 0f;
    protected AllPoolManager allPoolManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        allPoolManager = gameManager.allPoolManager;
    }
    private void Update()
    {
        Attack();
    }
  
    protected virtual void Attack()
    {
        timer += Time.deltaTime;
        if (timer >= firerate)
        {
            timer = 0f;
            newbullet = allPoolManager.GetPool(1);
            newbullet.transform.position = transform.position;
            diff = gameManager.Player.transform.position - transform.position;
            diff.Normalize();
            rotaitionZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            newbullet.transform.rotation = Quaternion.Euler(0f, 0f, rotaitionZ - 180f);
            newbullet.transform.SetParent(null);
            newbullet.gameObject.SetActive(true);
        }
    }
}


