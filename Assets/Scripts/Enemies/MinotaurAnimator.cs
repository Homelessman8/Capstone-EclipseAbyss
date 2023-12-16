using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MinotaurAnimator : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    Transform target;

    //bool isWalking;

    void Awake()
    {
        animator.SetBool("isIdle", true);
    }

    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    void Update()
    {
       if(target)
       {
            //isWalking = true;
            Vector3 direction = (target.position - transform.position).normalized;
            animator.SetBool("isWalking", true);
       }
    }
}
