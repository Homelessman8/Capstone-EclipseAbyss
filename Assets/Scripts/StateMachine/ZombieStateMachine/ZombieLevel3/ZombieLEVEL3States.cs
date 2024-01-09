using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ZombieLEVEL3States 
{
    public abstract void OnStateEnter(ZombieLEVEL3StateManager zombie3Manager);
    public abstract void OnStateUpdate(ZombieLEVEL3StateManager zombie3Manager);
    public abstract void OnStateExit(ZombieLEVEL3StateManager zombie3Manager);
}
