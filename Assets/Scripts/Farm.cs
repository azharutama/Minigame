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

    public List<Question> questions;
    public AudioSource questionAudioSource;
    public AudioSource correctSound;
    public AudioSource wrongSound;
    public Text finalMessageText;



    private Question currentQuestion;
    private int questionIndex = 0;


    void Start()
    {
        if (questions.Count > 0)
        {
            ShuffleQuestions();
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
        Invoke(nameof(LoadSwamp), 2f);
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


    public void LoadHome()
    {

        SceneManager.LoadScene("PilihLatar");
    }

    public void LoadSavana()
    {
        SceneManager.LoadScene("savana");
    }

    public void LoadSwamp()
    {
        SceneManager.LoadScene("swamp");
    }
}
