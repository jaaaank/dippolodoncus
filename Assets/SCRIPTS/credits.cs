using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class credits : MonoBehaviour
{
    public Scene mainmenu;
    // Start is called before the first frame update

    public void backButton()
    {
        SceneManager.LoadScene("mainmenu");
    }
    public void linkbutton(string wah)
    {
        Application.OpenURL(wah);
    }
}
