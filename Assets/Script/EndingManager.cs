using UnityEngine;

public class EndingManager : MonoBehaviour
{
    public GameObject endScreen;
    public GameObject dialoguePanel;
    public GameObject player;
    public GameObject monasBackground;

    public void EndGame()
    {
        Invoke("ShowEnding", 1.5f);
    }

    void ShowEnding()
    {
        dialoguePanel.SetActive(false);
        player.SetActive(false);
        monasBackground.SetActive(false);

        endScreen.SetActive(true);
    }
}