using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
	// This script is to be placed on the same object as the UnitScript, otherwise it won't work
	[SerializeField] private Slider Bar;
	[SerializeField] private float Roughness = 5;
	private UnitScript UnitToRead;
	private void Awake()
	{
		// Prevent a crash that shouldn't ever occur anyway
		if (Roughness <= 0)
		{
			Roughness = 1;
		}

		// Search for the HP Bar asset
		if (Bar == null)
		{
			Debug.LogWarning("HPBar on " + gameObject.name + " doesn't have a bar to write too! you probably forgot to set one!");
			Destroy(this); // Destroy this so it doesnt crash in the future, we've already bugged people enough with the line above this
		}

		// Get the rest of the unit
		UnitToRead = gameObject.GetComponent<UnitScript>();
	}
	private void Update()
	{
		Bar.maxValue = UnitToRead.MaxHP;
		// This next part is overcomplicated, but the smoothing looks pretty...
		if (Bar.value < UnitToRead.HP)
		{
			Bar.value = Mathf.Clamp(Bar.value - Roughness * Time.deltaTime, UnitToRead.HP, Bar.maxValue);
		} else
		{
			Bar.value = Mathf.Clamp(Bar.value + Roughness * Time.deltaTime, UnitToRead.HP, Bar.maxValue);
		}
		
	}
}
