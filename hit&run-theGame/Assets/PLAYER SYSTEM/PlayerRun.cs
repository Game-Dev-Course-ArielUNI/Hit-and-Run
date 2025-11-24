using UnityEngine;

public class PlayerRun : MonoBehaviour
{
    public float speed = 6f;

    private void Update()
    {
        if (GameManager.Instance.playerState.state != PlayerStateEnum.Running)
            return;

        transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FinishLine"))
        {
            GameManager.Instance.OnPlayerReachedFinishLine();
        }
    }
}
