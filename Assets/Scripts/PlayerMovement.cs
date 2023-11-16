using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 7.5f;
	private Vector3 movementVector = Vector3.zero;
	public void Movement(InputAction.CallbackContext context)
	{
		movementVector = new(context.ReadValue<Vector2>().x, 0, context.ReadValue<Vector2>().y);
	}
	private void Update()
	{
		transform.Translate(speed * Time.deltaTime * movementVector);
	}
}
