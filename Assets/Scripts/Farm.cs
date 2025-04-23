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
        public AudioClip questionSound;  // Suara pertanyaan
        public string correctAnswer;     // Jawaban benar (nama hewan)
    }

    public List<Question> questions = new List<Question>(); // List pertanyaan
    public AudioSource questionAudioSource; // AudioSource untuk memainkan suara pertanyaan
    public AudioSource correctSound; // Suara benar
    public AudioSource wrongSound; // Suara salah
    public Text scoreText; // UI untuk menampilkan skor

    private Question currentQuestion;
    private int score = 0;
    private int questionIndex = 0;
    private int pointPerQuestion = 0;

    void Start()
    {
        if (questions.Count > 0)
        {
            ShuffleQuestions();

            // Hitung nilai per soal secara otomatis agar total jadi 100
            pointPerQuestion = Mathf.RoundToInt(100f / questions.Count);

            DisplayQuestion();
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
        if (selectedAnswer == currentQuestion.correctAnswer)
        {
            correctSound.Play();
            score += pointPerQuestion;
            questionIndex++;
            DisplayQuestion();
        }
        else
        {
            wrongSound.Play();
        }
    }

    void EndGame()
    {
        scoreText.text = "Game Selesai! Skor: " + score;
        Invoke("swamp", 2f); // Pindah ke scene savana setelah 2 detik
    }


    public void Home()
    {
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
