using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

      public void pilihLatar()
    {
        StartCoroutine(LoadSceneWithDelay("PilihLatar"));
    }

    public void quit()
    {
        Application.Quit();
    }
    
 

    IEnumerator LoadSceneWithDelay(string sceneName)
    {
        yield return new WaitForSeconds(0.2f); 
        SceneManager.LoadScene(sceneName);
    }
}
