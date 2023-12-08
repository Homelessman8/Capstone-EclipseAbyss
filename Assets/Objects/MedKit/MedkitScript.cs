using UnityEngine;
using static StatusConditions;

public class MedkitScript : MonoBehaviour
{
    private bool CanInteract = true;
    private class Medicine : Status
    {
        private int HealingLeft;
        private float HealingSpeed;
        private float HealCooldown;

        public Medicine(Sprite image, Color color, int Healamount, float Healspeed)
        {
            // Triggers when applied
            HealingLeft = Healamount;
            HealingSpeed = Healspeed;
            HealCooldown = 0f;

            IsDisplayedOnStatBar = true;
            StatusColor = color;
            StatBarSprite = image;
        }

        public override bool Process(UnitScript unit)
        {
            // Triggers every frame
            HealCooldown += Time.deltaTime * HealingSpeed * Mathf.Clamp(HealingLeft / 4, 1, 100);
            if (HealCooldown > 1f && HealingLeft > 0)
            {
                HealCooldown -= 1;
                HealingLeft -= 1;
                unit.HP += 1;
            }
            DisplayText = HealingLeft.ToString();
            if (HealingLeft <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    // Stats for the Medkit
    [Header("Condition Bar")]
    public Sprite displayImage = null;
    public Color conditionColor = Color.green;
    [Header("Healing")]
    public int HealAmount = 80;
    public float HealSpeed = 1;
    public void Interact(UnitScript who)
    {
        // This may seem pointless, but raycasting is weird, so it is possible (and actually really common) that it can be interacted twice.
        if (CanInteract)
        {
            CanInteract = false;
            who.Conditions.Add(new Medicine(displayImage, conditionColor, Mathf.CeilToInt(HealAmount/4f*3f), HealSpeed));
            who.HP += Mathf.FloorToInt(HealAmount / 4f);
            Destroy(gameObject); // EAT THE MEDKIT WHOLE
        }
    }
}
