using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
	// Character speed
	public float speed = 4.5f;
	// This variable isn't used to track anything, if you want dashing to be part of an ability or something, feel free to adjust
	public bool IsDashingAllowed = true;
	// Direction of movement, as inputted by the player
	private Vector3 movementVector = Vector3.zero;

	public float DashTimeMax = 1;
	private float DashTime = 1;
	public float DashCooldownMax = 3;
	private float DashCooldown = 3;
	// The dash is also affected by movement speed, so it stays usefull
	public float DashPower = 5;
	private Vector3 DashDirection = Vector3.zero;

	public void Movement(InputAction.CallbackContext context)
	{ // Each time the movement changes, save it as a vector
		movementVector = new(context.ReadValue<Vector2>().x, 0, context.ReadValue<Vector2>().y);
	}

	public void Dash()
	{
		if (IsDashingAllowed && DashCooldown <= 0)
		{
			DashCooldown = DashCooldownMax;
			DashTime = DashTimeMax;
			DashDirection = (DashPower * speed * (movementVector + new Vector3(0,0.05f,0))); // Adding a bit to vertical so we arent dragging against the ground
		}
	}

	private void Update()
	{   
		if (DashCooldown > 0)
		{
			DashCooldown -= Time.deltaTime;
		}
		if (DashTime > 0)
		{ 
			transform.Translate(DashDirection * DashTime * Time.deltaTime); // Multiplying it by DashTime means it should slowly decay
			DashTime -= Time.deltaTime;
		}

		// Move along the saved vector
		transform.Translate(speed * Time.deltaTime * movementVector);
	}
}
