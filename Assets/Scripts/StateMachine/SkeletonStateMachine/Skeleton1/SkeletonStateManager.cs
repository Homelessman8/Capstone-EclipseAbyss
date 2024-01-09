using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonStateManager : MonoBehaviour
{
    [Header("State Machine")]
    public SkeletonIdleState idleState = new SkeletonIdleState();
    public SkeletonFollowState followState = new SkeletonFollowState();
    public SkeletonAttackState attackState = new SkeletonAttackState();
    public SkeletonStates currentState;

    [Header("Actual References")]
    public Transform[] targetPoints;
    public Transform enemyEyes;
    public float playerCheckDistance;
    public float checkRadius;

    [HideInInspector]
    public NavMeshAgent agent;

    public Transform playerTransform;

    public float moveSpeed;

    public Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentState = idleState;
        currentState.OnStateEnter(this);
    }


    void Update()
    {
       
        transform.LookAt(playerTransform);
        
        currentState.OnStateUpdate(this);
    }

    public void ChangeState(SkeletonStates newstate)
    {
        currentState.OnStateExit(this);
        currentState = newstate;
        currentState.OnStateEnter(this);
    }
}
