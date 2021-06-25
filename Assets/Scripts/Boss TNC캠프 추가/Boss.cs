using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField]
    protected GameObject boss;
    [SerializeField]
    private GameObject bullet = null;
    [SerializeField]
    private float speed = 5f;
    private GameManager gameManager;
    void Start()
    {
        //BossSpawn();
        //StartCoroutine(CircleShot());
    }
    void Awake()
    {
      //  Attack();
    }

    public void BossSpawn()
    {
        Instantiate(boss, new Vector2(8f, 0f), Quaternion.identity);
    }

    private IEnumerator CircleShot()
    {
        while (true)
        {
            for (int i = 0; i < 180; i += 13)
            {

                GameObject temp = Instantiate(bullet);
                Destroy(temp, 2f);
                temp.transform.position = transform.position;
                temp.transform.rotation = Quaternion.Euler(0, 0, i);
            }
            yield return new WaitForSeconds(5f);

        }
    }
  
}
