using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public QuizManager quizManager;

    Queue<string> lines = new Queue<string>();

    bool isDialogueActive = false;

    public void StartDialogue(string[] dialogueLines)
    {
        dialoguePanel.SetActive(true);
        isDialogueActive = true;

        lines.Clear();

        foreach (string line in dialogueLines)
        {
            lines.Enqueue(line);
        }

        ShowNextLine();
    }

    public void ShowNextLine()
    {
        if (lines.Count == 0)
        {
            EndDialogue();
            return;
        }

        dialogueText.text = lines.Dequeue();
    }

    void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        isDialogueActive = false;

        quizManager.StartQuiz();
    }

    public bool IsDialogueActive()
    {
        return isDialogueActive;
    }
}