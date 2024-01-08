using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject bossWalls;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            bossWalls.gameObject.SetActive(true);
            Destroy(enemies[3]);
        }
       
    }
}
