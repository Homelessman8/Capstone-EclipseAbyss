using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFollowState : ZombieStates
{
    public override void OnStateEnter(ZombieStateManager zombieManager)
    {
        zombieManager.transform.LookAt(zombieManager.playerTransform);
        zombieManager.animator.SetBool("isWalking", true);
        Debug.Log("Zombie is Following");
    }

    public override void OnStateExit(ZombieStateManager zombieManager)
    {
        Debug.Log("Skeleton Stopped Following Player");
    }

    public override void OnStateUpdate(ZombieStateManager zombieManager)
    {
        //ExitCondition to Idle State if distance to large
        if (zombieManager.playerTransform != null)
        {
            if (Vector3.Distance(zombieManager.transform.position, zombieManager.playerTransform.position) > 7f)
            {
                zombieManager.animator.SetBool("isWalking", false);
                zombieManager.ChangeState(zombieManager.idleState);
            }

            //Exit Condition to Attack State if distance is too small
            if (Vector3.Distance(zombieManager.transform.position, zombieManager.playerTransform.position) < 1f)
            {
                zombieManager.ChangeState(zombieManager.attackState);
            }

            zombieManager.agent.destination = zombieManager.playerTransform.position;
        }
        else
        {
            zombieManager.ChangeState(zombieManager.idleState);
        }
    }

}
