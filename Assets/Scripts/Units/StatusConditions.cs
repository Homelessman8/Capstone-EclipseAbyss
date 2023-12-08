using UnityEngine;

public class StatusConditions : MonoBehaviour
{
    public abstract class Status
    {
        public bool UsesTimer = false;
        public float TimeUntilGone = -1;

        public bool IsDisplayedOnStatBar = false;
        public Sprite StatBarSprite = null;
        public Color StatusColor = Color.white;
        public string DisplayText = "0";
        public virtual bool Process(UnitScript unit)
        {
            // Triggers every frame
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
            // Happens when the timer expires if the timer is included.
        }
    }
}
