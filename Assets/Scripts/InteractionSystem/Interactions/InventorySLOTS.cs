using UnityEngine;
using UnityEngine.UI;

public class InventorySLOTS : MonoBehaviour
{
    public Image[] slots;        // UI slot images
    public Sprite[] itemIcons;   // Icons for items

    void Start()
    {
        UpdateUI(); // Initialize UI at start
    }

    public void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < Inventory.instance.items.Count)
            {
                slots[i].enabled = true;
                slots[i].sprite = itemIcons[i];
            }
            else
            {
                slots[i].enabled = false;
            }
        }
    }
}