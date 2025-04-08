using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   

    public void pilihLatar()
    {
        SceneManager.LoadScene("pilihLatar");
    }

    public void quit()
    {
        Application.Quit();
    }
}
