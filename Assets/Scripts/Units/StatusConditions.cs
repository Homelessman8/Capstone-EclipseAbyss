using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusConditions : MonoBehaviour
{
    public abstract class Status
    {
        public bool IsDisplayedOnStatBar = false;
		public bool UsesTimer = false;
		public Sprite StatBarSprite = null;
        public float TimeUntilGone = -1;
        public virtual bool Process(UnitScript unit)
        {
            if (UsesTimer)
            {
                TimeUntilGone -= Time.deltaTime;
                if (TimeUntilGone < 0)
                {
                    OnTimeout();
                    return true;
                }
            }
            return false;
        }
        public virtual void OnTimeout()
        {
			// Really great function, right here. so amazing
		}
	}
}
