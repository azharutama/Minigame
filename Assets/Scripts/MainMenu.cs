using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PilihLatar()
    {
        StartCoroutine(LoadSceneWithDelay("PilihLatar"));
    }
    public void Farm ()
    {
        StartCoroutine(LoadSceneWithDelay("farm"));
    }

     public void Credit()
    {
        StartCoroutine(LoadSceneWithDelay("credit"));
    }


    public void Quit()
    {
        Application.Quit();
    }



    IEnumerator LoadSceneWithDelay(string sceneName)
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(sceneName);
    }
}
