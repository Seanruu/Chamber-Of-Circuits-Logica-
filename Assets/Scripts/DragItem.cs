using UnityEngine;

public class DragItem : MonoBehaviour
{
    public float dragDistance = 2.5f;
    public KeyCode dragKey = KeyCode.E;
    public float pickupRange = 5f;
    public float moveSpeed = 10f;

    private bool isDragging = false;
    private Transform playerCamera;
    private Rigidbody rb;

    void Start()
    {
        playerCamera = Camera.main.transform;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(dragKey))
        {
            if (!isDragging)
                TryPickUp();
            else
                DropItem();
        }
    }

    void FixedUpdate()
    {
        if (isDragging)
        {
            Vector3 targetPosition =
                playerCamera.position + playerCamera.forward * dragDistance;

            rb.MovePosition(Vector3.Lerp(
                transform.position,
                targetPosition,
                moveSpeed * Time.fixedDeltaTime
            ));
        }
    }

    void TryPickUp()
    {
        Ray ray = new Ray(playerCamera.position, playerCamera.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, pickupRange))
        {
            if (hit.transform == transform)
            {
                isDragging = true;

                rb.useGravity = false;
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }

    void DropItem()
    {
        isDragging = false;
        rb.useGravity = true;
    }
}