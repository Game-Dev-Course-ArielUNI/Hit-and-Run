using UnityEngine;
using System.Collections;

public class CameraIntroMove : MonoBehaviour
{
    public Transform outsidePoint;
    public Transform insidePoint;
    public float moveDuration = 4f;

    private void Start()
    {
        if (outsidePoint == null || insidePoint == null)
        {
            Debug.LogError("Camera points not assigned!");
            return;
        }

        StartCoroutine(MoveCamera());
    }

    private IEnumerator MoveCamera()
    {
        transform.position = outsidePoint.position;
        transform.rotation = outsidePoint.rotation;

        float elapsed = 0f;

        while (elapsed < moveDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / moveDuration;

            transform.position = Vector3.Lerp(
                outsidePoint.position,
                insidePoint.position,
                t
            );

            transform.rotation = Quaternion.Slerp(
                outsidePoint.rotation,
                insidePoint.rotation,
                t
            );

            yield return null;
        }

        transform.position = insidePoint.position;
        transform.rotation = insidePoint.rotation;
    }
}
