using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPooler : MonoBehaviour
{
    [SerializeField]
    private int setIndex;
    public int index  { get; private set; }
    private GameManager gameManager = null;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        index = setIndex;
    }

    public void DeSpawn()
    {
        transform.SetParent(gameManager.allPoolManager.transform);
        gameObject.SetActive(false);
    } 
}
