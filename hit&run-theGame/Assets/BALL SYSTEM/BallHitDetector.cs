using UnityEngine;

public class BallHitDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.Instance.phase != GamePhase.Run) return;

        if (other.CompareTag("Player"))
        {
            GameManager.Instance.OnEnemyBallHitPlayer();
        }
    }
}
