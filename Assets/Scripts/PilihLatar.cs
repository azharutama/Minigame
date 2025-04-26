using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PilihLatar : MonoBehaviour
{
    public void LoadSavana()
    {
        StartCoroutine(LoadSceneWithDelay("savana"));
    }

    public void LoadFarm()
    {
        StartCoroutine(LoadSceneWithDelay("farm"));
    }

    public void LoadSwamp()
    {
        StartCoroutine(LoadSceneWithDelay("swamp"));
    }

    public void LoadCredit()
    {
        StartCoroutine(LoadSceneWithDelay("credit"));
    }

    public void LoadHome()
    {
        StartCoroutine(LoadSceneWithDelay("MainMenu"));
    }

    IEnumerator LoadSceneWithDelay(string sceneName)
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(sceneName);
    }
}
