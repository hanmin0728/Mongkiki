using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPooler : MonoBehaviour
{
    [SerializeField]
    private int setIndex;
    public int index  { get; private set; }

    void Start()
    { 
        index = setIndex;
    }

    public void DeSpawn()
    {
        transform.SetParent(GameManager.Instance.AllPoolManager.transform);
        gameObject.SetActive(false);    
    } 

}
