using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pilihLatar : MonoBehaviour
{


    public void savana()
    {
        SceneManager.LoadScene("savana");
    }
    public void farm()
    {
        SceneManager.LoadScene("farm");
    }
    public void swamp()
    {
        SceneManager.LoadScene("swamp");
    }
    public void credit()
    {
        SceneManager.LoadScene("credit");
    }



    public void home()
    {
        SceneManager.LoadScene("MainMenu");
    }

 
}
