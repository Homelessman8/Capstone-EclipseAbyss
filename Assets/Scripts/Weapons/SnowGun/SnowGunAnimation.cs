using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowGunAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    public GameObject Gun;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetBool("isAiming", true);
        }

        if (Input.GetMouseButtonUp(1))
        {
            animator.SetBool("isAiming", false);
        }
    }
}
