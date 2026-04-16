using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public string itemName = "Item";
    public float rotationSpeed = 50f; // Speed of spinning

    void Update()
    {
        // Rotate the item continuously
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    public void Interact()
    {
        Inventory.instance.AddItem(itemName);

        Destroy(gameObject);
    }
}