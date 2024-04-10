using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttackState : ZombieStates
{
    public override void OnStateEnter(ZombieStateManager zombieManager)
    {
        zombieManager.animator.SetBool("isAttacking", true);
        Debug.Log("Attacking Player");
    }

    public override void OnStateExit(ZombieStateManager zombieManager)
    {
        Debug.Log("Zombie is no longer Attacking");
    }

    public override void OnStateUpdate(ZombieStateManager zombieManager)
    {
        //Exit condition to go back to follow
        if (Vector3.Distance(zombieManager.transform.position, zombieManager.playerTransform.position) < 2f)
        {
            zombieManager.animator.SetBool("isAttacking", false);
            zombieManager.ChangeState(zombieManager.followState);
        }
    }
}
