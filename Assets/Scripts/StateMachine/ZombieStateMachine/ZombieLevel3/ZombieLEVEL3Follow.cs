using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieLEVEL3Follow : ZombieLEVEL3States
{
    public override void OnStateEnter(ZombieLEVEL3StateManager zombie3Manager)
    {
        zombie3Manager.transform.LookAt(zombie3Manager.playerTransform);
        zombie3Manager.animator.SetBool("isWalking", true);
        Debug.Log("Zombie is Following");
    }

    public override void OnStateExit(ZombieLEVEL3StateManager zombie3Manager)
    {
        Debug.Log("Skeleton Stopped Following Player");
    }

    public override void OnStateUpdate(ZombieLEVEL3StateManager zombie3Manager)
    {
        //ExitCondition to Idle State if distance to large
        if (zombie3Manager.playerTransform != null)
        {
            if (Vector3.Distance(zombie3Manager.transform.position, zombie3Manager.playerTransform.position) > 100f)
            {
                zombie3Manager.animator.SetBool("isWalking", false);
                zombie3Manager.ChangeState(zombie3Manager.idle3State);
            }

            //Exit Condition to Attack State if distance is too small
            if (Vector3.Distance(zombie3Manager.transform.position, zombie3Manager.playerTransform.position) < 1f)
            {
                zombie3Manager.ChangeState(zombie3Manager.attack3State);
            }

            zombie3Manager.agent.destination = zombie3Manager.playerTransform.position;
        }
        else
        {
            zombie3Manager.ChangeState(zombie3Manager.idle3State);
        }
    }
}
