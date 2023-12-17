using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieStateManager : MonoBehaviour
{
    [Header("State Machine")]
    public ZombieIdleState idleState = new ZombieIdleState();
    public ZombieFollowState followState = new ZombieFollowState();
    public ZombieAttackState attackState = new ZombieAttackState();
    public ZombieStates currentState;

    [Header("Actual References")]
    public Transform[] targetPoints;
    public Transform enemyEyes;
    public float playerCheckDistance;
    public float checkRadius;

    [HideInInspector]
    public NavMeshAgent agent;

    [HideInInspector]
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
        currentState.OnStateUpdate(this);
    }

    public void ChangeState(ZombieStates newstate)
    {
        currentState.OnStateExit(this);
        currentState = newstate;
        currentState.OnStateEnter(this);
    }
}
