using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pilihLatar : MonoBehaviour
{
    public void savana()
    {
        StartCoroutine(LoadSceneWithDelay("savana"));
    }

    public void farm()
    {
        StartCoroutine(LoadSceneWithDelay("farm"));
    }

    public void swamp()
    {
        StartCoroutine(LoadSceneWithDelay("swamp"));
    }

    public void credit()
    {
        StartCoroutine(LoadSceneWithDelay("credit"));
    }

    public void home()
    {
        StartCoroutine(LoadSceneWithDelay("MainMenu"));
    }

    IEnumerator LoadSceneWithDelay(string sceneName)
    {
        yield return new WaitForSeconds(0.2f); // Delay 1 detik
        SceneManager.LoadScene(sceneName);
    }
}
