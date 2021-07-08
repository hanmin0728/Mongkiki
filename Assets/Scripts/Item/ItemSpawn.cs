using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject[] items = new GameObject[3];
    private List<int> randompersent = new List<int> { 20, 40, 40 };
   
    private void Start()
    {
        StartCoroutine(SpawnItem());
    }

    private IEnumerator SpawnItem()
    {
        while (true)
        {
            float randomx = Random.Range(GameManager.Instance.MinPosition.x, GameManager.Instance.MaxPosition.x);
            yield return new WaitForSeconds(3f);
            GameObject obj = GameManager.Instance.AllPoolManager.GetPool(ReturnRandomInterger() + 4);
            obj.transform.position = new Vector2(randomx, 10);
            obj.transform.position = new Vector2(Mathf.Clamp(obj.transform.position.x, -10f, 9f),
             Mathf.Clamp(obj.transform.position.y, -3.7f, 3.9f));
            obj.SetActive(true);
            yield return new WaitForSeconds(3.5f);
        }
    }

    private int ReturnRandomInterger()
    {
        int total = 0;
        foreach (int persent in randompersent)
        {
            total += persent;
        }

        int rand = Random.Range(0, total);

        for (int i = 0; i < randompersent.Count; i++)
        {
            if (rand < randompersent[i])
            {
                return i;
            }
            else
            {
                rand -= randompersent[i];
            }
        }
        return 0;
    }
}
