using UnityEngine;

public class PlayerDodge : MonoBehaviour
{
    public float laneOffset = 2f;
    public float jumpForce = 8f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (GameManager.Instance.playerState.state != PlayerStateEnum.Running)
            return;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            transform.position += Vector3.left * laneOffset;

        if (Input.GetKeyDown(KeyCode.RightArrow))
            transform.position += Vector3.right * laneOffset;

        if (Input.GetKeyDown(KeyCode.Space))
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
