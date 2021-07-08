using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{ 

    [SerializeField]
    private GameObject bulletPrefab = null;
    [SerializeField]
    private Transform bulletPosition = null;
    public float bulletDelay = 3f;

    [SerializeField]
    private Sprite[] item;

    private Animator animator = null;

    public int attackPower = 1;

    public int state;
    private float stateTime = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(Fire());
    }

    void Update()
    {
        TimeOut();
    }

    private IEnumerator Fire()
    {
        while (true)
        {
            if (Input.GetMouseButton(0))
            {
                PoolSpawn();
                animator.SetTrigger("Attack");
                yield return new WaitForSeconds(bulletDelay);
            }
            yield return null;
        }
    }
    
    private void PoolSpawn()
    {
        GameObject stone = null;
        if (GameManager.Instance.PoolManager.transform.childCount > 0)
        {
            stone = GameManager.Instance.PoolManager.transform.GetChild(0).gameObject;
            stone.transform.position = bulletPosition.position;
            stone.SetActive(true);
        }
        else
        {
            stone = Instantiate(bulletPrefab, bulletPosition.position, Quaternion.identity);
        }
        stone.transform.SetParent(null);
        stone.GetComponent<SpriteRenderer>().sprite = item[state];
    }

    public void StartResetAttackPower()
    {
        StartCoroutine(ResetAttackPower());
    }

    private IEnumerator ResetAttackPower()
    {
        yield return new WaitForSeconds(3f);
        attackPower = 1;
    }

    public void StartResetBulletDelay()
    {
        StartCoroutine(ResetBulletDelay());
    }

    private IEnumerator ResetBulletDelay()
    {
        yield return new WaitForSeconds(3f);
        bulletDelay = 0.3f;
    }

    private void TimeOut()
    {
        if (state == 0) return;
        stateTime += Time.deltaTime;
        if (stateTime > 3f)
        {
            stateTime = 0f;
            state = 0;
        }
    }   

}
