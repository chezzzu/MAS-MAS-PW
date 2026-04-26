using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class DialogueLine
{
    public string speaker;
    public string text;
    public Sprite portrait;
}

public class IntroDialogueManager : MonoBehaviour
{
    public DialogueLine[] dialogueLines;

    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI nameText;
    public Image portraitImage;

    public GameObject choicePanel;

    int index = 0;

    void Start()
    {
        ShowDialogue();
    }

    public void NextDialogue()
    {
        index++;

        if (index < dialogueLines.Length)
        {
            ShowDialogue();
        }
        else
        {
            choicePanel.SetActive(true);
        }
    }

    void ShowDialogue()
    {
        dialogueText.text = dialogueLines[index].text;
        nameText.text = dialogueLines[index].speaker;
        portraitImage.sprite = dialogueLines[index].portrait;
    }

    public void ChooseOption()
    {
        choicePanel.SetActive(false);

        Invoke("LoadMonasScene", 1.5f);
    }

    void LoadMonasScene()
    {
        SceneManager.LoadScene("Monas_Gameplay");
    }
}