using UnityEngine;

public class BallPhysics : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Pile"))
        {
            GameManager.Instance.pileController.OnBallHitPile();
        }
    }
}
