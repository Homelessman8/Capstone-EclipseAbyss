using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinotaurStateManager : MonoBehaviour
{
    [Header("State Machine")]
    public MinotaurIdleState minotaurIdleState = new MinotaurIdleState();
    public MinotaurFollowState minotaurFollowState = new MinotaurFollowState();
    public MinotaurAttackState minotaurAttackState = new MinotaurAttackState();
    public MinotaurStates minotaurCurrentState;

    [Header("Actual References")]
    public Transform[] targetPoints;
    public Transform enemyEyes;
    public float playerCheckDistance;
    public float checkRadius;

    [HideInInspector]
    public NavMeshAgent agent;

    public float moveSpeed;

    public Transform playerTransform;

    public Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        minotaurCurrentState = minotaurIdleState;
        minotaurCurrentState.OnStateEnter(this);
    }


    void Update()
    {
        transform.LookAt(playerTransform);
        minotaurCurrentState.OnStateUpdate(this);
    }

    public void ChangeState(MinotaurStates newstate)
    {
        minotaurCurrentState.OnStateExit(this);
        minotaurCurrentState = newstate;
        minotaurCurrentState.OnStateEnter(this);
    }
}
