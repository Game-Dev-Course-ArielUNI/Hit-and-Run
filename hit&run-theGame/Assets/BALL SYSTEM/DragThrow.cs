using UnityEngine;

public class DragThrowZOnly : MonoBehaviour
{
    [Header("Throw tuning")]
    public float maxPullPixels = 250f;   // how many pixels you can drag
    public float maxThrowForceZ = 20f;  // max impulse along +Z

    private Camera cam;
    private Rigidbody rb;

    private Vector3 startWorldPos;       // original ball position in world
    private float startMouseY;           // mouse Y when we start dragging
    private bool isDragging = false;

    private void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();

        startWorldPos = transform.position;
        rb.isKinematic = true;          // ball visible, doesn’t fall at start
    }

    private void OnMouseDown()
    {
        if (!isDragging)
        {
            isDragging = true;
            startMouseY = Input.mousePosition.y;
            startWorldPos = transform.position;
            rb.isKinematic = true;      // freeze physics while dragging
        }
    }

    private void OnMouseDrag()
    {
        if (!isDragging) return;

        float currentMouseY = Input.mousePosition.y;
        float pullPixels = Mathf.Clamp(startMouseY - currentMouseY, 0f, maxPullPixels);
        float t = pullPixels / maxPullPixels;   // 0..1

        // Move ball backwards along -Z while dragging (visual feedback)
        float maxBackDistance = 2f;  // how far visually the ball can move back
        float backZ = -t * maxBackDistance;

        transform.position = new Vector3(
            startWorldPos.x,
            startWorldPos.y,
            startWorldPos.z + backZ
        );
    }

    private void OnMouseUp()
    {
        if (!isDragging) return;
        isDragging = false;

        float releaseMouseY = Input.mousePosition.y;
        //float pullPixels = Mathf.Clamp(startMouseY - releaseMouseY, 0f, maxPullPixels);
        float pullPixels = Mathf.Clamp(releaseMouseY - startMouseY, 0f, maxPullPixels);


        float t = pullPixels / maxPullPixels;   // 0..1

        // Calculate final force along +Z (toward pile)
        float forceZ = t * maxThrowForceZ;

        rb.isKinematic = false;
        rb.linearVelocity = Vector3.zero;
        rb.AddForce(new Vector3(0f, 0f, forceZ), ForceMode.Impulse);

        // (optional) lock X/Y so physics won't move sideways
        // rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
    }
}
