using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 12f;
    private GameManager gameManager;
    private AllPooler allPooler;

    void Start()
    {
        allPooler = GetComponent<AllPooler>();
        gameManager = FindObjectOfType<GameManager>();
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
        if (transform.position.y < gameManager.MinPosition.y -2f)
        {
            allPooler.DeSpawn();
        }
    }
}
