using System.Collections;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject beeHousePrefab;
    [SerializeField]
    private GameObject enemyMonkeyPrefab = null;
    private GameManager gameManager = null;
 
    private GameObject newbeehouse;
   
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        StartCoroutine(SpawnBeeHouse());
    }

    private IEnumerator SpawnBeeHouse()
    {
        while (true)
        {
            for (int i = 0; i < 3; i++)
            {
                float randomY = Random.Range(3.7f, -3.7f);
                newbeehouse = gameManager.allPoolManager.GetPool(2);
                newbeehouse.transform.position = new Vector2(8f,randomY);
                newbeehouse.gameObject.SetActive(true);
                newbeehouse.GetComponent<BeeHouseEnemyMove>().hp = 2;
                newbeehouse.GetComponent<BeeHouseEnemyMove>().isDead = false;
                newbeehouse.GetComponent<BeeHouseEnemyMove>().isDamaded= false;
                yield return new WaitForSeconds(1f);
            }
            yield return new WaitForSeconds(5f);
        }
    }

    public void MonkeySpawn()
    {

        GameObject[] objs = new GameObject[2];

            for (int i = 0; i < 2; i++)
            {
                objs[i] = gameManager.allPoolManager.GetPool(0);
                objs[i].gameObject.SetActive(true);
                objs[i].GetComponent<MonkeyColision>().hp = 5;
                objs[i].GetComponent<MonkeyColision>().isDead = false;
            }

        for (int i = 0; i < 2; i++)
        {
            float randomY = Random.Range(3.7f, -3.7f); 
            float randomX = Random.Range(7.5f, 8f);
            Vector3 pos = new Vector3(randomX, randomY, 0);
            if (i == 1)
            {
                Vector2 distance = pos - objs[0].transform.position;
                if (distance.magnitude < 2f)
                {
                    pos += (Vector3)(distance.normalized * 2f);
                }
            }
            objs[i].transform.position = pos;
            objs[i].transform.position = new Vector2(Mathf.Clamp(objs[i].transform.position.x, -10f, 9f),
                Mathf.Clamp(objs[i].transform.position.y, -3.7f, 3.9f));  //만약 포지션이 넘어가면 다시 안넘어가는 값으로초기화
        }
    }

}
