using UnityEngine;
using UnityEngine.Events;

public class InventoryDisUse : MonoBehaviour
{
    public InventoryObject InvObject;
    public UnityEvent UseEffect;

    public void Use()
    {
        Debug.Log(InvObject.DisplayName + " has been used.");
        UseEffect.Invoke();
        Destroy(InvObject.gameObject);
        Destroy(gameObject);
    }
    public void Discard()
    {
        Destroy(InvObject.gameObject);
        Destroy(gameObject);
    }
}
