using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Farm : MonoBehaviour
{
    [System.Serializable]
    public class Question
    {
        public AudioClip questionSound;
        public string correctAnswer;
    }

    public List<Question> questions = new List<Question>();
    public AudioSource questionAudioSource;
    public AudioSource correctSound;
    public AudioSource wrongSound;
    public Text finalMessageText;

    // Hapus variabel sound click
    // public AudioSource buttonAudioSource;
    // public AudioClip buttonClickSound;

    private Question currentQuestion;
    private int score = 0;
    private int questionIndex = 0;
    private int pointPerQuestion = 0;

    void Start()
    {
        if (questions.Count > 0)
        {
            ShuffleQuestions();
            pointPerQuestion = Mathf.RoundToInt(100f / questions.Count);
            StartCoroutine(PlayQuestionWithDelay(2.5f));
        }
    }

    void ShuffleQuestions()
    {
        for (int i = 0; i < questions.Count; i++)
        {
            Question temp = questions[i];
            int randomIndex = Random.Range(i, questions.Count);
            questions[i] = questions[randomIndex];
            questions[randomIndex] = temp;
        }
    }

    void DisplayQuestion()
    {
        if (questionIndex < questions.Count)
        {
            currentQuestion = questions[questionIndex];
            questionAudioSource.loop = false;
            questionAudioSource.clip = currentQuestion.questionSound;
            questionAudioSource.Play();
        }
        else
        {
            EndGame();
        }
    }

    public void Answer(string selectedAnswer)
    {
        questionAudioSource.Stop();

        if (selectedAnswer == currentQuestion.correctAnswer)
        {
            correctSound.Play();
            score += pointPerQuestion;
            questionIndex++;
            StartCoroutine(NextQuestionWithDelay(1.5f));
        }
        else
        {
            wrongSound.Play();
        }
    }

    void EndGame()
    {
        finalMessageText.text = "SELAMAT KAMU BERHASIL!";
        Invoke("swamp", 2f);
    }

    IEnumerator PlayQuestionWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        DisplayQuestion();
    }

    IEnumerator NextQuestionWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        DisplayQuestion();
    }

    // Hapus fungsi PlayClickSound karena tidak digunakan lagi
    /*
    void PlayClickSound()
    {
        if (buttonAudioSource != null && buttonClickSound != null)
        {
            buttonAudioSource.PlayOneShot(buttonClickSound);
        }
    }
    */

    public void Home()
    {
        // Tidak perlu PlayClickSound
        SceneManager.LoadScene("PilihLatar");
    }

    public void savana()
    {
        SceneManager.LoadScene("savana");
    }

    public void swamp()
    {
        SceneManager.LoadScene("swamp");
    }
}
