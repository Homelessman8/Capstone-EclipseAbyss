using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurAttackState : MinotaurStates
{
    public override void OnStateEnter(MinotaurStateManager minotaurManager)
    {
        minotaurManager.animator.SetBool("isAttacking", true);
        Debug.Log("Attacking Player");
    }

    public override void OnStateExit(MinotaurStateManager minotaurManager)
    {
        Debug.Log("Minotaur is no longer Attacking");
    }

    public override void OnStateUpdate(MinotaurStateManager minotaurManager)
    {


        //Exit condition to go back to follow
        if (Vector3.Distance(minotaurManager.transform.position, minotaurManager.playerTransform.position) < 6f)
        {
            minotaurManager.animator.SetBool("isAttacking", false);
            minotaurManager.ChangeState(minotaurManager.minotaurFollowState);
        }
    }
}
