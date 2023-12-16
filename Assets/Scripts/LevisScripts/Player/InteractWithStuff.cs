using UnityEngine;

public class InteractWithStuff : MonoBehaviour
{
	public float MaxInteractDistance;
	private Camera Cam;
	private InventoryScript PickUpTo;

	private void Start()
	{
		PickUpTo = GameObject.Find("Canvas").GetComponentInChildren<InventoryScript>();
		Cam = GetComponent<Camera>();
	}
	public void Interact()
	{
		Ray rei = Cam.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2)); // Get the center of the screen

		// Interact with whatever is in the center of the screen.
		if (Physics.Raycast(rei, out RaycastHit RayHit, MaxInteractDistance))
		{
			RayHit.collider.gameObject.BroadcastMessage(
				"Interact", // Tells the object to be interacted with
				gameObject.GetComponentInParent<UnitScript>(), // Tell the object what is interacting with it
				SendMessageOptions.DontRequireReceiver // Don't crash if the object cant be interacted with
			);
		}

		Debug.DrawRay(rei.origin, rei.direction, Color.yellow, 3);
	}
	public void PickUp()
	{
        Ray rei = Cam.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2)); // Get the center of the screen

        // Interact with whatever is in the center of the screen.
        if (Physics.Raycast(rei, out RaycastHit RayHit, MaxInteractDistance))
        {
            RayHit.collider.gameObject.BroadcastMessage(
                "PickUp", // Tells the object to be interacted with
				PickUpTo, // Get the inventory
                SendMessageOptions.DontRequireReceiver // Don't crash if the object cant be interacted with
            );
        }

        Debug.DrawRay(rei.origin, rei.direction, Color.yellow, 3);
    }
}
