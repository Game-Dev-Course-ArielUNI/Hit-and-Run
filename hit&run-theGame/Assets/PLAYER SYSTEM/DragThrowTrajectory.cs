using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(Rigidbody))]
public class DragThrowTrajectory : MonoBehaviour
{
    [Header("Throw Settings")]
    public float maxDragDistance = 5f;
    public float throwMultiplier = 20f;

    [Header("Trajectory Settings")]
    public int predictionSteps = 30;
    public float stepTime = 0.1f;

    private LineRenderer line;
    private Rigidbody rb;

    private Vector3 dragStart;
    private bool isDragging = false;
    private Vector3 startPosition;   // where the ball starts

    void Start()
    {
        line = GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody>();

        line.positionCount = 0;

        startPosition = transform.position;   // remember start spot
        rb.isKinematic = true;               // ball is visible but doesn’t fall
    }

    void Update()
    {
        if (GameManager.Instance.phase != GamePhase.Throw)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            dragStart = GetMouseWorldPoint();
        }

        if (isDragging)
        {
            Vector3 dragCurrent = GetMouseWorldPoint();
            ShowTrajectory(dragStart, dragCurrent);
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            Vector3 dragEnd = GetMouseWorldPoint();
            ThrowBall(dragStart, dragEnd);

            line.positionCount = 0; // clear line
            isDragging = false;
        }
    }

    Vector3 GetMouseWorldPoint()
    {
        // ground plane at y = 0 (can change if your ground is higher)
        Plane plane = new Plane(Vector3.up, 0f);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        float enter;
        if (plane.Raycast(ray, out enter))
            return ray.GetPoint(enter);

        return Vector3.zero;
    }

    void ThrowBall(Vector3 start, Vector3 end)
    {
        // calculate drag vector (start - end so pulling back = forward throw)
        Vector3 dragVector = start - end;
        dragVector = Vector3.ClampMagnitude(dragVector, maxDragDistance);

        if (dragVector.sqrMagnitude < 0.0001f)
            return; // tiny drag → do nothing

        Vector3 direction = dragVector.normalized;

        // reset ball to start position and enable physics
        transform.position = startPosition;
        rb.isKinematic = false;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // apply force to THIS ball (no Instantiate)
        rb.AddForce(direction * dragVector.magnitude * throwMultiplier, ForceMode.Impulse);

        GameManager.Instance.OnPlayerThrowFinished();
    }

    void ShowTrajectory(Vector3 start, Vector3 current)
    {
        Vector3 dragVector = start - current;
        dragVector = Vector3.ClampMagnitude(dragVector, maxDragDistance);

        Vector3 direction = dragVector.normalized;
        Vector3 initialVelocity = direction * dragVector.magnitude * throwMultiplier / 1.5f;

        Vector3 pos = startPosition;   // trajectory starts from the ball
        Vector3 vel = initialVelocity;

        List<Vector3> points = new List<Vector3>();

        for (int i = 0; i < predictionSteps; i++)
        {
            points.Add(pos);
            vel += Physics.gravity * stepTime;
            pos += vel * stepTime;
        }

        line.positionCount = points.Count;
        line.SetPositions(points.ToArray());
    }
}









//using UnityEngine;
//using System.Collections.Generic;

//[RequireComponent(typeof(LineRenderer))]
//public class DragThrowTrajectory : MonoBehaviour
//{
//    [Header("Throw Settings")]
//    public GameObject ballPrefab;
//    public Transform throwPoint;
//    public float maxDragDistance = 5f;
//    public float throwMultiplier = 20f;

//    [Header("Trajectory Settings")]
//    public int predictionSteps = 30;
//    public float stepTime = 0.1f;

//    private LineRenderer line;
//    private Vector3 dragStart;
//    private bool isDragging = false;

//    void Start()
//    {
//        line = GetComponent<LineRenderer>();
//        line.positionCount = 0;
//    }

//    void Update()
//    {
//        if (GameManager.Instance.phase != GamePhase.Throw)
//            return;

//        if (Input.GetMouseButtonDown(0))
//        {
//            isDragging = true;
//            dragStart = GetMouseWorldPoint();
//        }

//        if (isDragging)
//        {
//            Vector3 dragCurrent = GetMouseWorldPoint();

//            ShowTrajectory(dragStart, dragCurrent);
//        }

//        if (Input.GetMouseButtonUp(0) && isDragging)
//        {
//            Vector3 dragEnd = GetMouseWorldPoint();
//            ThrowBall(dragStart, dragEnd);

//            line.positionCount = 0; // clear line
//            isDragging = false;
//        }
//    }

//    Vector3 GetMouseWorldPoint()
//    {
//        Plane plane = new Plane(Vector3.up, 0);  // ground plane at y=0
//        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

//        float enter;
//        if (plane.Raycast(ray, out enter))
//            return ray.GetPoint(enter);

//        return Vector3.zero;
//    }

//    void ThrowBall(Vector3 start, Vector3 end)
//    {
//        GameObject ball = Instantiate(ballPrefab, throwPoint.position, Quaternion.identity);
//        Rigidbody rb = ball.GetComponent<Rigidbody>();

//        Vector3 dragVector = start - end; // direction + power
//        dragVector = Vector3.ClampMagnitude(dragVector, maxDragDistance);

//        Vector3 direction = dragVector.normalized;

//        rb.AddForce(direction * dragVector.magnitude * throwMultiplier, ForceMode.Impulse);

//        GameManager.Instance.OnPlayerThrowFinished();
//    }

//    void ShowTrajectory(Vector3 start, Vector3 current)
//    {
//        Vector3 dragVector = start - current;
//        dragVector = Vector3.ClampMagnitude(dragVector, maxDragDistance);

//        Vector3 direction = dragVector.normalized;
//        Vector3 initialVelocity = direction * dragVector.magnitude * throwMultiplier / 1.5f;

//        Vector3 pos = throwPoint.position;
//        Vector3 vel = initialVelocity;

//        List<Vector3> points = new List<Vector3>();

//        for (int i = 0; i < predictionSteps; i++)
//        {
//            points.Add(pos);
//            vel += Physics.gravity * stepTime;
//            pos += vel * stepTime;
//        }

//        line.positionCount = points.Count;
//        line.SetPositions(points.ToArray());
//    }
//}
