using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieLEVEL3Idle : ZombieLEVEL3States
{
    private int currentTargetPoint = 0;
    public override void OnStateEnter(ZombieLEVEL3StateManager zombie3Manager)
    {
        zombie3Manager.agent.destination = zombie3Manager.targetPoints[currentTargetPoint].position;
        Debug.Log("Zombie is Idling");
    }

    public override void OnStateExit(ZombieLEVEL3StateManager zombie3Manager)
    {
        Debug.Log("No Longer Idling");
    }

    public override void OnStateUpdate(ZombieLEVEL3StateManager zombie3Manager)
    {
        //Idling Behaviour
        if (zombie3Manager.agent.remainingDistance < 0.1f)
        {
            currentTargetPoint++;
            if (currentTargetPoint >= zombie3Manager.targetPoints.Length)
            {
                currentTargetPoint = 0;
            }
            zombie3Manager.agent.destination = zombie3Manager.targetPoints[currentTargetPoint].position;

        }

        // ExitCondition
        if (Physics.SphereCast(zombie3Manager.enemyEyes.position, zombie3Manager.playerCheckDistance, zombie3Manager.transform.forward, out RaycastHit hit, zombie3Manager.playerCheckDistance))
        {
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("Player Found");
                zombie3Manager.playerTransform = hit.transform;
                zombie3Manager.agent.destination = zombie3Manager.playerTransform.position;

                zombie3Manager.ChangeState(zombie3Manager.follow3State);
            }
        }
    }
}
