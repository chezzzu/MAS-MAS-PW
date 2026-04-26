using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public GameObject quizPanel;

    public TMP_Text questionText;
    public TMP_Text answerAText;
    public TMP_Text answerBText;
    public TMP_Text answerCText;

    public TMP_Text resultText;

    int correctAnswer;

    bool answered = false;

    public void StartQuiz()
    {
        quizPanel.SetActive(true);

        resultText.gameObject.SetActive(false);

        questionText.text = "Berapa tinggi Monas?";

        answerAText.text = "120 meter";
        answerBText.text = "132 meter";
        answerCText.text = "150 meter";

        correctAnswer = 1;

        answered = false;
    }

    public void ChooseAnswer(int answer)
    {
        if (answered) return;

        answered = true;

        resultText.gameObject.SetActive(true);

        if (answer == correctAnswer)
        {
            resultText.text = "Jawaban Benar!";
            resultText.color = Color.green;
        }
        else
        {
            resultText.text = "Jawaban Salah!";
            resultText.color = Color.red;
        }

        Invoke("LoadFinalScene", 2f);
    }

    void LoadFinalScene()
    {
        quizPanel.SetActive(false);
        SceneManager.LoadScene("FinalScene");
    }

    public bool IsQuizActive()
    {
        return quizPanel.activeSelf;
    }
}