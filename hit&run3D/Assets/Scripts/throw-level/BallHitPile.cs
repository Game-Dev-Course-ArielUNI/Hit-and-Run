using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BallHitPile : MonoBehaviour
{
    [Header("Scene Transition")]
    [SerializeField] private string nextSceneName = "NextScene";
    [SerializeField] private float delaySeconds = 5f;

    private bool hasTriggered = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (hasTriggered) return;

        if (collision.transform.root.CompareTag("Pile"))
        {
            hasTriggered = true;
            StartCoroutine(LoadNextSceneAfterDelay());
        }
    }

    private IEnumerator LoadNextSceneAfterDelay()
    {
        yield return new WaitForSeconds(delaySeconds);
        SceneManager.LoadScene(nextSceneName);
    }
}
