using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ZombieStates 
{
    public abstract void OnStateEnter(ZombieStateManager zombieManager);
    public abstract void OnStateUpdate(ZombieStateManager zombieManager);
    public abstract void OnStateExit(ZombieStateManager zombieManager);
}
