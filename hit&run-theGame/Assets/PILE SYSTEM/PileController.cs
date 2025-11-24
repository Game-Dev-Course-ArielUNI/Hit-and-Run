using UnityEngine;

public class PileController : MonoBehaviour
{
    public int fallenCount = 0;

    public void RegisterFall()
    {
        fallenCount++;
    }

    public void OnBallHitPile()
    {
        GameManager.Instance.OnPileHit(fallenCount);
    }
}
