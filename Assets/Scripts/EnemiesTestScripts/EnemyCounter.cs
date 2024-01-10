using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    GameObject[] enemies;
    public TextMeshProUGUI enemyCountText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //enemies = GameObject.FindGameObjectWithTag("Enemy");

        enemyCountText.text = "Enemies: " + enemies.Length.ToString();
    }
}
