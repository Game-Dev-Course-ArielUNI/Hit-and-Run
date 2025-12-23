using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    //public TextMeshProUGUI highScoreText;
    //public TextMeshProUGUI gemsText;

    //public Animator messageAnim;

    private void Start()
    {
        Time.timeScale = 1;
    }
    //private void Update()
    //{
    //    highScoreText.text = "High Score\n" + PlayerPrefs.GetInt("HighScore", 0);
    //    gemsText.text = PlayerPrefs.GetInt("TotalGems", 0).ToString();
    //}
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
