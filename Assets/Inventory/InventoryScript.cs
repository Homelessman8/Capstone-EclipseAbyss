using UnityEngine;
using UnityEngine.Events;

public class InventoryScript : MonoBehaviour
{
    public bool isOpen = false;
    public GameObject UseMenuPrefab = null;
    private GameObject currentMenuPrefab = null;
    private GameObject content = null;

    private void Start()
    {
        if (UseMenuPrefab == null)
        {
            Debug.LogError("The InventoryScript is missing a UseMenuPrefab! it wont work without this!!!");
        }
        content = transform.Find("MainBox").gameObject;
    }
    public void OpenInventory()
    {
        
        if (isOpen)
        {
            isOpen = false;
            gameObject.BroadcastMessage("DisableUI");
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            if (currentMenuPrefab != null)
            {
                Destroy(currentMenuPrefab);
                currentMenuPrefab = null;
            }
        }
        else
        {
            isOpen = true;
            gameObject.BroadcastMessage("EnableUI");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    // We're trying to use an item, so create the menu
    public void StartDetail(InventoryObject InvObject)
    {
        if (currentMenuPrefab != null)
        {
            Destroy(currentMenuPrefab);
        }
        currentMenuPrefab = Instantiate(UseMenuPrefab, transform);
        currentMenuPrefab.transform.position = new Vector3(InvObject.transform.position.x, InvObject.transform.position.y, -1);
        InventoryDisUse SubMenu = currentMenuPrefab.GetComponent<InventoryDisUse>();
        SubMenu.UseEffect = InvObject.OnUseEffect;
        SubMenu.InvObject = InvObject;

    }

    // We're adding an item to the inventory
    public void AddAnItem(GameObject prefab)
    {
        InventoryObject catgirl = Instantiate(prefab, content.transform).GetComponent<InventoryObject>();
        // Setup anything we cant do on this end
        catgirl.SetupDetails();
    }
}
