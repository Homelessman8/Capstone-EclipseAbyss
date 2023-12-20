using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton2AttackState : Skeleton2States
{
    public override void OnStateEnter(Skeleton2StateManager manager2)
    {
        manager2.animator.SetBool("isAttacking", true);
        Debug.Log("Attacking Player");
    }

    public override void OnStateExit(Skeleton2StateManager manager2)
    {
        Debug.Log("Skeleton is no longer Attacking");
    }

    public override void OnStateUpdate(Skeleton2StateManager manager2)
    {


        //Exit condition to go back to follow
        if (Vector3.Distance(manager2.transform.position, manager2.playerTransform.position) < 5f)
        {
            manager2.animator.SetBool("isAttacking", false);
            manager2.ChangeState(manager2.followState);
        }
    }
}
