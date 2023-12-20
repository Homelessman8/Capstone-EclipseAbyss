using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Shield : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Animator swordAnimator;

    public GameObject greenShield;

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetBool("isShield", true);
            swordAnimator.SetBool("isThrusting", false);
            swordAnimator.SetBool("isSlashing", false);
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            animator.SetBool("isShield", false);
            swordAnimator.SetBool("isThrusting", true);
            swordAnimator.SetBool("isSlashing", true);
        }
    }
}
