using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBoss : MonoBehaviour
{
    [SerializeField]
    private GameObject boosPrefab;
    void Start()
    {
        Instantiate(boosPrefab, new Vector2(9f, 0f), Quaternion.identity);
    }

    void Update()
    {
        
    }
}
