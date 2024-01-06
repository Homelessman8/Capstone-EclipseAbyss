using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChangeTextRotator : MonoBehaviour
{
    private Transform playerTransform;
    private Vector3 offset = new Vector3(0, 180, 0);

    private void Start()
    {
        playerTransform = GameObject.Find("First Person Camera").GetComponent<Transform>(); 
    }

    void Update()
    {
        transform.LookAt(playerTransform);
        transform.Rotate(offset);
    }
}
