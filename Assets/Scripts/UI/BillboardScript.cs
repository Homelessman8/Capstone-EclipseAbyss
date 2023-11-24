using UnityEngine;

public class BillboardScript : MonoBehaviour
{
    public Camera faceCamera;
    private void Awake() // Awake is like start, but it triggers when instatiated as well
    {
        if (faceCamera == null) { faceCamera = Camera.main; }
    }
    void LateUpdate() // LateUpdate is the same as update, but with less priority
    {
        transform.LookAt(faceCamera.transform);
        transform.Rotate(0, 180, 0); // We have to rotate or itll be sideways.
    }
}
