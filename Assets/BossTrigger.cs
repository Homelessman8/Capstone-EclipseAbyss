using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public MinotaurHealthUi minotaurHealthBar;

    public GameObject enemies;
    public GameObject bossWalls;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            minotaurHealthBar.gameObject.SetActive(true);
            bossWalls.gameObject.SetActive(true);
            Destroy(enemies);
        }
       
    }
}
