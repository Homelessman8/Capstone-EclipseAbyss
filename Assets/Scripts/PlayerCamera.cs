using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera : MonoBehaviour
{
	public bool CanCamera = true; // Disable to lock the camera
	public float RotationSpeed = 20f;
	private Transform ParentObject;
	private float actualRotation = 0;

	private void Start()
	{
		ParentObject = transform.parent.transform;
	}

	public void CameraMoved(InputAction.CallbackContext context)
	{
		if (CanCamera)
		{
			// Get the difference in pixels of the mouse position since last frame
			Vector2 MoveDelta = context.ReadValue<Vector2>();

			actualRotation += (RotationSpeed * Time.deltaTime * MoveDelta.y * -1f);
			actualRotation = Mathf.Clamp(actualRotation, -80f, 80f);
			transform.rotation = Quaternion.Euler(new Vector3(actualRotation, transform.rotation.eulerAngles.y, 0));

			ParentObject.Rotate(RotationSpeed * Time.deltaTime * MoveDelta.x * Vector3.up);

			
		}
	}
}
