using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton2StateManager : MonoBehaviour
{
    [Header("State Machine")]
    public Skeleton2IdleState idleState = new Skeleton2IdleState();
    public Skeleton2FollowState followState = new Skeleton2FollowState();
    public Skeleton2AttackState attackState = new Skeleton2AttackState();
    public Skeleton2States currentState;

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

    public void ChangeState(Skeleton2States newstate)
    {
        currentState.OnStateExit(this);
        currentState = newstate;
        currentState.OnStateEnter(this);
    }
}
