using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float interactDistance = 3f;
    public LayerMask interactLayer;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance, interactLayer))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                // 🚪 DOOR
                DoorInteract door = hit.collider.GetComponentInParent<DoorInteract>();
                if (door != null)
                {
                    door.Interact();
                    return;
                }

                // 📦 CHEST
                ChestInteract chest = hit.collider.GetComponentInParent<ChestInteract>();
                if (chest != null)
                {
                    chest.Interact();
                    return;
                }

                // 💎 ITEM
                ItemPickup item = hit.collider.GetComponent<ItemPickup>();
                if (item != null)
                {
                    item.Interact();
                    return;
                }
            }
        }
    }
}