using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEndQuota : MonoBehaviour
{
    GameObject enemies;
    public GameObject endPortal;

    void Update()
    {
        EnemyQuota();
    }
    public void EnemyQuota()
    {
        enemies = GameObject.FindGameObjectWithTag("Enemy");
        if(enemies == null)
        {
            endPortal.gameObject.SetActive(true);
        }
        else
        {
            endPortal.gameObject.SetActive(false);
        }
    }
}
