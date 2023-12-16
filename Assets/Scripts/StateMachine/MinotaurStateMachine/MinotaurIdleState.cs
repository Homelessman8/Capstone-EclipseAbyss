using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurIdleState : MinotaurStates
{
    private int currentTargetPoint = 0;
    public override void OnStateEnter(MinotaurStateManager minotaurManager)
    {
        minotaurManager.agent.destination = minotaurManager.targetPoints[currentTargetPoint].position;
        minotaurManager.animator.SetBool("isIdle", true);
        Debug.Log("Minotaur is Idling");
    }

    public override void OnStateExit(MinotaurStateManager minotaurManager)
    {
        Debug.Log("No Longer Idling");
    }

    public override void OnStateUpdate(MinotaurStateManager minotaurManager)
    {
        //Idling Behaviour
        
        if (minotaurManager.agent.remainingDistance < 0.1f)
        {
            currentTargetPoint++;
            if (currentTargetPoint >= minotaurManager.targetPoints.Length)
            {
                currentTargetPoint = 0;
            }
            minotaurManager.agent.destination = minotaurManager.targetPoints[currentTargetPoint].position;

        }

        // ExitCondition
        if (Physics.SphereCast(minotaurManager.enemyEyes.position, minotaurManager.playerCheckDistance, minotaurManager.transform.forward, out RaycastHit hit, minotaurManager.playerCheckDistance))
        {
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("Player Found");
                minotaurManager.playerTransform = hit.transform;
                minotaurManager.agent.destination = minotaurManager.playerTransform.position;

                minotaurManager.ChangeState(minotaurManager.minotaurFollowState);
            }
        }
    }
}
