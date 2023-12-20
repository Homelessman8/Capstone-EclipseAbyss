using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton2IdleState : Skeleton2States
{
    private int currentTargetPoint = 0;
    public override void OnStateEnter(Skeleton2StateManager manager2)
    {
        manager2.agent.destination = manager2.targetPoints[currentTargetPoint].position;
        manager2.animator.SetBool("isWalking", true);
        Debug.Log("Skeleton is Idling");
    }

    public override void OnStateExit(Skeleton2StateManager manager2)
    {
        Debug.Log("No LongerIdling");
    }

    public override void OnStateUpdate(Skeleton2StateManager manager2)
    {
        
        //Idling Behaviour
        if (manager2.agent.remainingDistance < 0.1f)
        {
            currentTargetPoint++;
            if (currentTargetPoint >= manager2.targetPoints.Length)
            {
                currentTargetPoint = 0;
            }
            manager2.agent.destination = manager2.targetPoints[currentTargetPoint].position;

        }

        // ExitCondition
        if (Physics.SphereCast(manager2.enemyEyes.position, manager2.playerCheckDistance, manager2.transform.forward, out RaycastHit hit, manager2.playerCheckDistance))
        {
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("Player Found");
                manager2.playerTransform = hit.transform;
                manager2.agent.destination = manager2.playerTransform.position;

                manager2.ChangeState(manager2.followState);
            }
        }
    }
}
