using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPoolManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] prefab;

    private GameObject buket = null;

    private AllPooler allPooler; 
    public GameObject GetPool(int findIndex)
    {
        buket = null;
        for (int i = 0; i < transform.childCount; i++)
        {
            allPooler = transform.GetChild(i).GetComponent<AllPooler>();
            if (allPooler.index == findIndex)
            {
                buket = allPooler.gameObject;
                break;  
            }
        }
        if (buket == null)
        {
            buket = Instantiate(prefab[findIndex]);
            buket.SetActive(false);
        }
        else
        {
            buket.transform.SetParent(null);
        }
        return buket;
    }
}
