using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
  
    public void nextround()
    {
        SceneManager.LoadScene("easy run");
    }
    public void Quitgame()
    {
        Application.Quit();
    }
}
