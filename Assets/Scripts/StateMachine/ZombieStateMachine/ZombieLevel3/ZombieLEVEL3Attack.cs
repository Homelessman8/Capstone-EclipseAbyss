using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieLEVEL3Attack : ZombieLEVEL3States
{
    public override void OnStateEnter(ZombieLEVEL3StateManager zombie3Manager)
    {
        zombie3Manager.animator.SetBool("isAttacking", true);
        Debug.Log("Attacking Player");
    }

    public override void OnStateExit(ZombieLEVEL3StateManager zombie3Manager)
    {
        Debug.Log("Zombie is no longer Attacking");
    }

    public override void OnStateUpdate(ZombieLEVEL3StateManager zombie3Manager)
    {
        //Exit condition to go back to follow
        if (Vector3.Distance(zombie3Manager.transform.position, zombie3Manager.playerTransform.position) < 2f)
        {
            zombie3Manager.animator.SetBool("isAttacking", false);
            zombie3Manager.ChangeState(zombie3Manager.follow3State);
        }
    }
}
