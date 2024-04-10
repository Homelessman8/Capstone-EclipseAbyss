using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieIdleState : ZombieStates
{
    private int currentTargetPoint = 0;
    public override void OnStateEnter(ZombieStateManager zombieManager)
    {
        zombieManager.agent.destination = zombieManager.targetPoints[currentTargetPoint].position;
        Debug.Log("Zombie is Idling");
    }

    public override void OnStateExit(ZombieStateManager zombieManager)
    {
        Debug.Log("No Longer Idling");
    }

    public override void OnStateUpdate(ZombieStateManager zombieManager)
    {
        //Idling Behaviour
        if (zombieManager.agent.remainingDistance < 0.1f)
        {
            currentTargetPoint++;
            if (currentTargetPoint >= zombieManager.targetPoints.Length)
            {
                currentTargetPoint = 0;
            }
            zombieManager.agent.destination = zombieManager.targetPoints[currentTargetPoint].position;

        }

        // ExitCondition
        if (Physics.SphereCast(zombieManager.enemyEyes.position, zombieManager.playerCheckDistance, zombieManager.transform.forward, out RaycastHit hit, zombieManager.playerCheckDistance))
        {
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("Player Found");
                zombieManager.playerTransform = hit.transform;
                zombieManager.agent.destination = zombieManager.playerTransform.position;

                zombieManager.ChangeState(zombieManager.followState);
            }
        }
    }
}
