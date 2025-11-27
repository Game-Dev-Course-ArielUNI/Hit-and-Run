using UnityEngine;
using UnityEngine.InputSystem;

public class Jumper3D : MonoBehaviour
{
    [SerializeField] float jumpForce = 6.5f;

    [SerializeField] InputAction jump;

    private Rigidbody rb;

    void OnValidate()
    {
        if (jump == null)
            jump = new InputAction(type: InputActionType.Button);

        if (jump.bindings.Count == 0)
            jump.AddBinding("<Keyboard>/space");
    }

    private void OnEnable()
    {
        jump.Enable();
    }

    private void OnDisable()
    {
        jump.Disable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();  // <-- 3D Rigidbody
    }

    void Update()
    {
        if (jump.WasPressedThisFrame())
        {
            Jump();
        }
    }

    public void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);  // <-- 3D ForceMode
    }
}
