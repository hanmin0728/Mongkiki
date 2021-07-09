using System.Collections;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject pattern1;


    [SerializeField]
    private Transform enemyBulletPosition = null;
    [SerializeField]
    private GameObject enemyBulletPrefab = null;

    [SerializeField]
    private float speed = 6f;

    private float circleTimer = 0f;
    private float circleMaxTime = 3f;

    private bool isUse = false;
    private bool isPattern3 = false;
    private bool isPattern2 = false;

    private float timer = 0f;
    [SerializeField]
    private float firerate = 0.5f;

    private Vector2 diff = Vector2.zero; // diff는
    private float rotaitionZ = 0f;

    private float rotZ = -45f;
    private void Start()
    {
        // StartCoroutine(RandomPattern());
        SelectPattern();
    }

    //private IEnumerator RandomPattern()
    //{

    //    while (true)
    //    {
    //        Random.Range(0, 3);
    //        int random = Random.Range(0, 3);
    //        if (random == 0)
    //        {
    //            CreatePattern1();
    //        }
    //        else if (random == 1)
    //        {

    //            CreatePattern2();
    //            isUse = true;
    //            Debug.Log("sa");
    //            yield return new WaitForSeconds(1f);
    //            isUse = false;

    //        }
    //        else if (random == 2)
    //        {
    //            isPattern3 = true;
    //            //CreatePattern3();
    //            Debug.Log("sas");
    //            yield return new WaitForSeconds(1f);
    //            isPattern3 = false;

    //        }
    //        yield return new WaitForSeconds(3f);
    //    }
    //    yield return new WaitForSeconds(0f);
    //}
    private void SelectPattern()
    {

        //패턴이끝나면 다른ㄹ랜덤패턴실행
        Random.Range(0, 3);
        int random = Random.Range(0, 3);
        if (random == 0)
        {
            StartCoroutine(CreatePattern1());
            Debug.Log("S");
            isUse = false;
        }
        else if (random == 1)
        {

            StartCoroutine(CreatePattern2());
            Debug.Log("a");
            isPattern2 = false;

        }
        else if (random == 2)
        {

            StartCoroutine(CreatePattern3());
            Debug.Log("B");
            isPattern3 = false;

        }
    }
    private IEnumerator CreatePattern1()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(pattern1, this.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
        yield return new WaitForSeconds(1.5f);

        SelectPattern();

    }


    private IEnumerator CreatePattern2()
    {


        GameObject circleBullet = null;


        for (int i = 0; i < 10; i++)
        {
            if (GameManager.Instance.enemyPoolManager.transform.childCount > 0)
            {
                circleBullet = GameManager.Instance.enemyPoolManager.transform.GetChild(0).gameObject;
                circleBullet.transform.position = enemyBulletPosition.position;
                circleBullet.SetActive(true);
                circleBullet.transform.rotation = Quaternion.Euler(0, 0, rotZ);
                circleBullet.transform.SetParent(null);
        
            }
            else
            {

                circleBullet = Instantiate(enemyBulletPrefab, enemyBulletPosition.transform);
                circleBullet.transform.position = enemyBulletPosition.transform.position;
                circleBullet.transform.rotation = Quaternion.Euler(0, 0, rotZ);
                circleBullet.transform.SetParent(null);
            }
            yield return null;
            rotZ += 10f;
        }
        rotZ = -45f;
        yield return new WaitForSeconds(1.5f);

        SelectPattern();
    }

      
    private IEnumerator CreatePattern3()
    {
        GameObject boosBullet;
        // timer += Time.deltaTime;
        for (int i = 0; i < 10; i++)
        {

            //   timer = 0f;
            boosBullet = Instantiate(enemyBulletPrefab, transform);
            diff = GameManager.Instance.Player.transform.position - transform.position;
            diff.Normalize();
            rotaitionZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            boosBullet.transform.rotation = Quaternion.Euler(0f, 0f, rotaitionZ+180f);
            boosBullet.transform.SetParent(null);
            yield return new WaitForSeconds(0.3f);

        }
        yield return new WaitForSeconds(1.5f);

        SelectPattern();
    }
}
