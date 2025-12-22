using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
    
    void Start()
    {
        offset = transform.position - target.position;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newposition = new Vector3(transform.position.x, transform.position.y, offset.z + target.position.z);
        transform.position = newposition;
    }
}
