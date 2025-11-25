using UnityEngine;

public class BallHitDetector : MonoBehaviour
{
    private bool triggered = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (triggered) return;  // avoid double calls
        if (!GameManager.Instance) return;

        if (collision.collider.CompareTag("Pile"))
        {
            triggered = true;

            // Count how many objects fell (optional)
            //t fallen = GameManager.Instance.pileController.GetFallenCount();

            GameManager.Instance.OnPileHit(0);

            // Freeze the ball after impact
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.isKinematic = true;
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}




//using UnityEngine;

//public class BallHitDetector : MonoBehaviour
//{
//    private void OnTriggerEnter(Collider other)
//    {
//        if (GameManager.Instance.phase != GamePhase.Run) return;

//        if (other.CompareTag("Player"))
//        {
//            GameManager.Instance.OnEnemyBallHitPlayer();
//        }
//    }
//}
