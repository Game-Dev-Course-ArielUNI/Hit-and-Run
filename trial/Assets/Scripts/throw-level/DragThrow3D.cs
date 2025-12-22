using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DragThrow3D : MonoBehaviour
{
    [Header("Throw Settings")]
    [SerializeField] private float throwForceMultiplier = 10f;
    [SerializeField] private float maxDragDistance = 3f;

    private Rigidbody rb;
    private Camera cam;

    private Vector3 dragStartWorld;
    private bool isDragging = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    private void OnMouseDown()
    {
        isDragging = true;
        rb.isKinematic = true;

        dragStartWorld = GetMouseWorldPosition();
    }

    private void OnMouseDrag()
    {
        if (!isDragging) return;

        Vector3 currentDrag = GetMouseWorldPosition();
        Vector3 dragVector = currentDrag - dragStartWorld;

        if (dragVector.magnitude > maxDragDistance)
        {
            dragVector = dragVector.normalized * maxDragDistance;
        }

        transform.position = dragStartWorld + dragVector;
    }

    private void OnMouseUp()
    {
        isDragging = false;
        rb.isKinematic = false;

        Vector3 releaseWorld = GetMouseWorldPosition();
        Vector3 throwDirection = dragStartWorld - releaseWorld;

        rb.AddForce(throwDirection * throwForceMultiplier, ForceMode.Impulse);
    }

    private Vector3 GetMouseWorldPosition()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, transform.position);

        plane.Raycast(ray, out float distance);
        return ray.GetPoint(distance);
    }
}
