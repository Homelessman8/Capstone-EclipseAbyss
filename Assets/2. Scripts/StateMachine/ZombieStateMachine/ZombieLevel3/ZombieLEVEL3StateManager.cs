using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieLEVEL3StateManager : MonoBehaviour
{
    [Header("State Machine")]
    public ZombieLEVEL3Idle idle3State = new ZombieLEVEL3Idle();
    public ZombieLEVEL3Follow follow3State = new ZombieLEVEL3Follow();
    public ZombieLEVEL3Attack attack3State = new ZombieLEVEL3Attack();
    public ZombieLEVEL3States currentState;

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
        currentState = idle3State;
        currentState.OnStateEnter(this);
    }


    void Update()
    {
        transform.LookAt(playerTransform);
        currentState.OnStateUpdate(this);
    }

    public void ChangeState(ZombieLEVEL3States newstate3)
    {
        currentState.OnStateExit(this);
        currentState = newstate3;
        currentState.OnStateEnter(this);
    }
}
