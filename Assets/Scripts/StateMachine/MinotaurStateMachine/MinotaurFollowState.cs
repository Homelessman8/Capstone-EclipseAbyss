using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurFollowState : MinotaurStates
{
    public override void OnStateEnter(MinotaurStateManager minotaurManager)
    {
        minotaurManager.transform.LookAt(minotaurManager.playerTransform);
        minotaurManager.animator.SetBool("isWalking", true);
        Debug.Log("Minotaur is Following");
    }

    public override void OnStateExit(MinotaurStateManager minotaurManager)
    {
        Debug.Log("Minotaur Stopped Following Player");
    }

    public override void OnStateUpdate(MinotaurStateManager minotaurManager)
    {
        //ExitCondition to Idle State if distance to large
        if (minotaurManager.playerTransform != null)
        {
            if (Vector3.Distance(minotaurManager.transform.position, minotaurManager.playerTransform.position) > 10f)
            {
                minotaurManager.ChangeState(minotaurManager.minotaurIdleState);
                minotaurManager.animator.SetBool("isWalking", false);
                //minotaurManager.animator.SetBool("isIdle", true);

            }

            //Exit Condition to Attack State if distance is too small
            if (Vector3.Distance(minotaurManager.transform.position, minotaurManager.playerTransform.position) < 4f)
            {
                minotaurManager.ChangeState(minotaurManager.minotaurAttackState);
            }

            minotaurManager.agent.destination = minotaurManager.playerTransform.position;
        }
        else
        {
            minotaurManager.ChangeState(minotaurManager.minotaurIdleState);
        }
    }
}
