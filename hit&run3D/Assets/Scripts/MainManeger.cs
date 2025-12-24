using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1;
    }
    
    public void easyGame()
    {
        SceneManager.LoadScene("easy-throw");
    }
    public void mediumGame()
    {
        SceneManager.LoadScene("medium-throw");
    }
    public void hardGame()
    {
        SceneManager.LoadScene("hard-throw");
    }
    public void partA()
    {
        SceneManager.LoadScene("part a");
    }
    public void partB()
    {
        SceneManager.LoadScene("part b");
    }
    public void back()
    {
        SceneManager.LoadScene("menu-ex7");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
