using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public MinotaurHealthUi minotaurHealthBar;

    public GameObject enemies;
    public GameObject bossWalls;
    public GameObject bossCutScene;
    public GameObject bossTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            bossCutScene.SetActive(true);
            minotaurHealthBar.gameObject.SetActive(true);
            bossWalls.gameObject.SetActive(true);
            Destroy(enemies);
            Destroy(bossTrigger);
        }
       
    }
}
