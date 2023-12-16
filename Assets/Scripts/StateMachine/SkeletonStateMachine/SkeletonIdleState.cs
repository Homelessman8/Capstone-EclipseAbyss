using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonIdleState : SkeletonStates
{
    private int currentTargetPoint = 0;
    public override void OnStateEnter(SkeletonStateManager manager)
    {
        manager.agent.destination = manager.targetPoints[currentTargetPoint].position;
        manager.animator.SetBool("isidle", true);
        Debug.Log("Skeleton is Idling");
    }

    public override void OnStateExit(SkeletonStateManager manager)
    {
        Debug.Log("No LongerIdling");
    }

    public override void OnStateUpdate(SkeletonStateManager manager)
    {
        //Idling Behaviour
        if (manager.agent.remainingDistance < 0.1f)
        {
            currentTargetPoint++;
            if (currentTargetPoint >= manager.targetPoints.Length)
            {
                currentTargetPoint = 0; 
            }
            manager.agent.destination = manager.targetPoints[currentTargetPoint].position;
            
        }

        // ExitCondition
        if (Physics.SphereCast(manager.enemyEyes.position, manager.playerCheckDistance, manager.transform.forward, out RaycastHit hit, manager.playerCheckDistance))
        {
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("Player Found");
                manager.playerTransform = hit.transform;
                manager.agent.destination = manager.playerTransform.position;

                manager.ChangeState(manager.followState);
            }
        }
    }
}
