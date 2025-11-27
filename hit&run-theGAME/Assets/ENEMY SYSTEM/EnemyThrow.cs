using UnityEngine;

public class EnemyThrow : MonoBehaviour
{
    public GameObject enemyBallPrefab;
    public float throwForce = 18f;

    private EnemyBallPickup pickup;

    private void Start()
    {
        pickup = GetComponent<EnemyBallPickup>();
    }

    private void Update()
    {
        if (!pickup.hasBall) return;
        if (GameManager.Instance.phase != GamePhase.Run) return;

        ThrowBall();
        pickup.hasBall = false;
    }

    void ThrowBall()
    {
        GameObject b = Instantiate(enemyBallPrefab, transform.position, Quaternion.identity);
        Rigidbody rb = b.GetComponent<Rigidbody>();

        Vector3 playerPos = GameObject.FindWithTag("Player").transform.position;

        Vector3 dir = (playerPos - transform.position).normalized;

        rb.AddForce(dir * throwForce, ForceMode.Impulse);
    }
}
