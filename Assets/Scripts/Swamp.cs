using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Swamp : MonoBehaviour
{
    [System.Serializable]
    public class Question
    {
        public string questionText;  // Teks pertanyaan
        public string correctAnswer; // Jawaban benar (nama hewan)
    }

    public List<Question> questions = new List<Question>(); // List pertanyaan
    public Text questionTextUI; // UI untuk menampilkan pertanyaan
    public AudioSource correctSound; // Suara benar
    public AudioSource wrongSound; // Suara salah
    public Text scoreText; // UI untuk menampilkan skor

    private Question currentQuestion;
    private int score = 0;
    private int questionIndex = 0;

    void Start()
    {
        if (questions.Count > 0)
        {
            ShuffleQuestions();
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
            questionTextUI.text = currentQuestion.questionText;
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
            score += 25;
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
        questionTextUI.text = "Game Selesai! Skor: " + score;
    }

    public void Home()
    {
        SceneManager.LoadScene("PilihLatar");
    }

       public void savana()
    {
        SceneManager.LoadScene("savana");
    }
    public void farm()
    {
        SceneManager.LoadScene("farm");
    }
}
