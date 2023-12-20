using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkeletonStates
{
    public abstract void OnStateEnter(SkeletonStateManager manager);
    public abstract void OnStateUpdate(SkeletonStateManager manager);
    public abstract void OnStateExit(SkeletonStateManager manager);
}
