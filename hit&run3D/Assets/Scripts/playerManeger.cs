using Unity.VisualScripting;
using UnityEngine;

public class playerManeger : MonoBehaviour
{
    public static bool gameover;
    public GameObject gameoverpanel;

    public static bool gameWin;
    public GameObject winpanel;
    //public static bool isGamestarted;
    public GameObject startingtext;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameover = false;
        gameWin = false;
        Time.timeScale = 1;
        //isGamestarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(startingtext,2f);
        if (gameover)
        {
            Time.timeScale = 0;
            gameoverpanel.SetActive(true);

        }
        if (gameWin)
        {
            Time.timeScale = 0;
            winpanel.SetActive(true);

        }

    }
 
}
