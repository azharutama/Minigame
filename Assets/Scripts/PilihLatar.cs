using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pilihLatar : MonoBehaviour
{
    public AudioSource audioSource; // AudioSource dari GameObject
    public AudioClip buttonClickSound; // Suara klik tombol

    void PlayClickSound()
    {
        if (audioSource != null && buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound);
        }
    }

    public void savana()
    {
        PlayClickSound();
        SceneManager.LoadScene("savana");
    }

    public void farm()
    {
        PlayClickSound();
        SceneManager.LoadScene("farm");
    }

    public void swamp()
    {
        PlayClickSound();
        SceneManager.LoadScene("swamp");
    }

    public void credit()
    {
        PlayClickSound();
        SceneManager.LoadScene("credit");
    }

    public void home()
    {
        PlayClickSound();
        SceneManager.LoadScene("MainMenu");
    }
}
