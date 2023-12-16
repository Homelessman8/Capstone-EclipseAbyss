using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonFollowState : SkeletonStates
{
    public override void OnStateEnter(SkeletonStateManager manager)
    {
        manager.transform.LookAt(manager.playerTransform);
        manager.animator.SetBool("isWalking", true);
        Debug.Log("Skeleton is Following");
    }

    public override void OnStateExit(SkeletonStateManager manager)
    {
        Debug.Log("Skeleton Stopped Following Player");
    }

    public override void OnStateUpdate(SkeletonStateManager manager)
    {
        //ExitCondition to Idle State if distance to large
        if (manager.playerTransform != null)
        {
            if (Vector3.Distance(manager.transform.position, manager.playerTransform.position) > 7)
            {
                manager.ChangeState(manager.idleState);
                manager.animator.SetBool("isidle", true);

            }

            //Exit Condition to Attack State if distance is too small
            if (Vector3.Distance(manager.transform.position, manager.playerTransform.position) < 3)
            {
                manager.ChangeState(manager.attackState);
            }

            manager.agent.destination = manager.playerTransform.position;
        }
        else
        {
            manager.ChangeState(manager.idleState);
        }
    }
    
}
