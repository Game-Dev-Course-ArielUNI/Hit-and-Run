using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject winText;  // Assign in Inspector

    private void Awake()
    {
        Instance = this;
    }

    public void ShowWinText()
    {
        if (winText != null)
            winText.SetActive(true);
    }
}
