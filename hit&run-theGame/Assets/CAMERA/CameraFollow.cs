using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = 10f;

    void LateUpdate()
    {
        // Only follow in RUN phase (optional)
        if (GameManager.Instance.phase != GamePhase.Run)
            return;

        if (target == null) return;

        // Smooth follow
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
        );

        transform.position = smoothPosition;

        // --- FIX: Keep camera rotation stable ---
        // Do NOT rotate based on the player's sideways movement
        transform.rotation = Quaternion.Euler(25f, 0f, 0f);
    }
}
