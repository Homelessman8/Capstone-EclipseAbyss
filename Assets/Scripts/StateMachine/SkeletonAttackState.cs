using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttackState : SkeletonStates
{
    public override void OnStateEnter(SkeletonStateManager manager)
    {
        manager.animator.SetBool("isAttacking", true);
        Debug.Log("Attacking Player");
    }

    public override void OnStateExit(SkeletonStateManager manager)
    {
        Debug.Log("Skeleton is no longer Attacking");
    }

    public override void OnStateUpdate(SkeletonStateManager manager)
    {
        

        //Exit condition to go back to follow
        if (Vector3.Distance(manager.transform.position, manager.playerTransform.position) < 5f)
        {
            manager.animator.SetBool("isAttacking", false);
            manager.ChangeState(manager.followState);
        }
    }
}
