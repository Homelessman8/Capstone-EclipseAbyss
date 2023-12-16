using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Shield : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    public GameObject greenShield;
    public GameObject sword;

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetBool("isShield", true);
            sword.gameObject.SetActive(false);
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            animator.SetBool("isShield", false);
            sword.gameObject.SetActive(true);
        }
    }
}
