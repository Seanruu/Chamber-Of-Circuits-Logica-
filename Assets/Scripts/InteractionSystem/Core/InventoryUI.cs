using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Text inventoryText;

    void Update()
    {
        inventoryText.text = "Inventory:\n";

        foreach (string item in Inventory.instance.items)
        {
            inventoryText.text += item + "\n";
        }
    }
}