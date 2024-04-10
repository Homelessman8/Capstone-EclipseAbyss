using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MinotaurStates 
{
    public abstract void OnStateEnter(MinotaurStateManager minotaurManager);
    public abstract void OnStateUpdate(MinotaurStateManager minotaurManager);
    public abstract void OnStateExit(MinotaurStateManager minotaurManager);
}
