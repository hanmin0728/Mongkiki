using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 12f;

    private AllPooler allPooler;

    void Start()
    {
        allPooler = GetComponent<AllPooler>();
    }

    void Update()
    {
        MoveItem();
        Domain();
    }
    private void MoveItem()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
    private void Domain()
    {
        if (transform.position.y < GameManager.Instance.MinPosition.y -2f)
        {
            allPooler.DeSpawn();
        }
    }
}
