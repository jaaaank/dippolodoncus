using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void playGame()
    {
        SceneManager.LoadScene("Test gray box");
    }
    public void credits()
    {
        SceneManager.LoadScene("credits");
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
