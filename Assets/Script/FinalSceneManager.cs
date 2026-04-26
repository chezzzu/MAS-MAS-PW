using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class FinalDialogueLine
{
    public string speaker;
    public string text;
    public Sprite portrait;
}

public class FinalSceneManager : MonoBehaviour
{
    public FinalDialogueLine[] dialogueLines;

    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI nameText;
    public Image portraitImage;

    public GameObject dialoguePanel;
    public GameObject endTitle;
    public GameObject whiteBackground;

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
            Invoke("ShowEnd", 1.5f);
        }
    }

    void ShowDialogue()
    {
        dialogueText.text = dialogueLines[index].text;
        nameText.text = dialogueLines[index].speaker;
        portraitImage.sprite = dialogueLines[index].portrait;
    }

    void ShowEnd()
    {
        dialoguePanel.SetActive(false);
        whiteBackground.SetActive(true);
        endTitle.SetActive(true);
    }
}