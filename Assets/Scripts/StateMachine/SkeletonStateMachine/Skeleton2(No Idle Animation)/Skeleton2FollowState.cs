using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton2FollowState : Skeleton2States
{
    public override void OnStateEnter(Skeleton2StateManager manager2)
    {
        manager2.transform.LookAt(manager2.playerTransform);
        manager2.animator.SetBool("isWalking", true);
        //Debug.Log("Skeleton is Following");
    }

    public override void OnStateExit(Skeleton2StateManager manager2)
    {
        Debug.Log("Skeleton Stopped Following Player");
    }

    public override void OnStateUpdate(Skeleton2StateManager manager2)
    {
        //ExitCondition to Idle State if distance to large
        if (manager2.playerTransform != null)
        {
            if (Vector3.Distance(manager2.transform.position, manager2.playerTransform.position) > 100f)
            {
                
                manager2.ChangeState(manager2.idleState);
                manager2.animator.SetBool("isWalking", false);

                //manager.animator.SetBool("isidle", true);

            }

            //Exit Condition to Attack State if distance is too small
            if (Vector3.Distance(manager2.transform.position, manager2.playerTransform.position) < 2f)
            {
                manager2.ChangeState(manager2.attackState);
            }

            manager2.agent.destination = manager2.playerTransform.position;
        }
        else
        {
            manager2.animator.SetBool("isWalking", false);
            manager2.ChangeState(manager2.idleState);
        }
    }
}
