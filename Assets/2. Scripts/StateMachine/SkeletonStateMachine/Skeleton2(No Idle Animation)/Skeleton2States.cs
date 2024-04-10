using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skeleton2States
{
    public abstract void OnStateEnter(Skeleton2StateManager manager2);
    public abstract void OnStateUpdate(Skeleton2StateManager manager2);
    public abstract void OnStateExit(Skeleton2StateManager manager2);
}
