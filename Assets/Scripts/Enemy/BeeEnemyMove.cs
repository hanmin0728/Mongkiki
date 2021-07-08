using System.Collections;
using UnityEngine;

public class BeeEnemyMove : BeeHouseEnemyMove
{

    private int score2 = 50;

    protected override void Update()
    {
        base.Update();
    }

    protected override void Move()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    protected override IEnumerator ShowDead()
    {
        spriteRenderer.material.SetColor("_Color", new Color(1f, 1f, 1f, 1f));
        col.enabled = false;
        yield return new WaitForSeconds(0.2f);
        col.enabled = true;
        allPooler.DeSpawn();
        GameManager.Instance.AddScore(score2);
    }
  
 







}

