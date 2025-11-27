//using UnityEngine;

//public class DragThrow3D : MonoBehaviour
//{
//    public GameObject ballPrefab;
//    public Transform throwPoint;
//    public float maxDragDistance = 5f;
//    public float throwMultiplier = 20f;

//    private Vector3 dragStartPos;
//    private Vector3 dragEndPos;
//    private bool isDragging = false;

//    void Update()
//    {
//        if (GameManager.Instance.phase != GamePhase.Throw)
//            return;

//        if (Input.GetMouseButtonDown(0))
//        {
//            isDragging = true;
//            dragStartPos = GetMouseWorldPoint();
//        }

//        if (Input.GetMouseButtonUp(0) && isDragging)
//        {
//            dragEndPos = GetMouseWorldPoint();
//            ThrowBall();
//            isDragging = false;
//        }
//    }

//    Vector3 GetMouseWorldPoint()
//    {
//        Plane plane = new Plane(Vector3.up, Vector3.zero);  // ground plane
//        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

//        float enter;
//        if (plane.Raycast(ray, out enter))
//        {
//            return ray.GetPoint(enter);
//        }

//        return Vector3.zero;
//    }

//    void ThrowBall()
//    {
//        GameObject ball = Instantiate(ballPrefab, throwPoint.position, Quaternion.identity);
//        Rigidbody rb = ball.GetComponent<Rigidbody>();

//        Vector3 dragVector = dragStartPos - dragEndPos; // opposite direction of drag
//        dragVector = Vector3.ClampMagnitude(dragVector, maxDragDistance);

//        Vector3 throwDirection = dragVector.normalized;

//        rb.AddForce(throwDirection * dragVector.magnitude * throwMultiplier,
//                    ForceMode.Impulse);

//        GameManager.Instance.OnPlayerThrowFinished();
//    }
//}




















using UnityEngine;

public class PlayerThrow : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform throwPoint;
    public float throwForce = 20f;

    private void Update()
    {
        if (GameManager.Instance.phase != GamePhase.Throw) return;

        if (Input.GetMouseButtonDown(0))
        {
            ThrowBall();
        }
    }

    void ThrowBall()
    {
        GameObject ball = Instantiate(ballPrefab, throwPoint.position, throwPoint.rotation);
        Rigidbody rb = ball.GetComponent<Rigidbody>();

        Vector3 dir = throwPoint.forward;   // ← FIXED DIRECTION

        rb.AddForce(dir * throwForce, ForceMode.Impulse);

        GameManager.Instance.OnPlayerThrowFinished();
    }
}
