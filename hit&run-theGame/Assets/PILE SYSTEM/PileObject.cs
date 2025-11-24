using UnityEngine;

public class PileObject : MonoBehaviour
{
    private bool hasFallen = false;
    public PileController controller;

    private void Update()
    {
        if (!hasFallen && transform.position.y < 0.5f)
        {
            hasFallen = true;
            controller.RegisterFall();
        }
    }
}
