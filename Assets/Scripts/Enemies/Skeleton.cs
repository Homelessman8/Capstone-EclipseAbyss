using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Skeleton : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    public Transform target;
    public float skeletonSpeed;
    Rigidbody rb;

    void Awake()
    {
        animator.SetBool("isidle", true);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, target.position, skeletonSpeed * Time.deltaTime);
        rb.MovePosition(pos);
        transform.LookAt(target);
    }
}
