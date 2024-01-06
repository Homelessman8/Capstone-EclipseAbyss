using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowGunAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    public GameObject Gun;

    public bool isAiming = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isAiming = true;
            animator.SetBool("isAiming", true);
        }

        if (Input.GetMouseButtonUp(1))
        {
            isAiming = false;
            animator.SetBool("isAiming", false);
        }
    }
}
