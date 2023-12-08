using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class InventoryObject : MonoBehaviour
{
    public bool Usable = true;
    public UnityEvent OnUseEffect = null;
    public Sprite DisplayImage = null;
    public string DisplayName = "Error Object";
    public Color DisplayColor = Color.white;

    private InventoryScript Inventory = null;

    public void ShowDetail()
    {
        Inventory.StartDetail(this);
    }
    public void SetupDetails()
    {
        transform.GetComponentInChildren<TextMeshProUGUI>().text = DisplayName;
        GetComponent<Image>().color = DisplayColor;
        transform.Find("Image").GetComponent<Image>().sprite = DisplayImage;
    }
    private void Start()
    {
        SetupDetails();
        Inventory = transform.parent.GetComponentInParent<InventoryScript>();
    }
}
