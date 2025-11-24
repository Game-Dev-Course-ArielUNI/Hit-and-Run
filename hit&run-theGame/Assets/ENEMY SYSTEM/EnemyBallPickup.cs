using UnityEngine;

public class EnemyBallPickup : MonoBehaviour
{
    public bool hasBall = false;

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Ball"))
        {
            hasBall = true;
            Destroy(col.gameObject);
        }
    }
}
