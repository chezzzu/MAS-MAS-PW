using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string[] dialogue;

    public void Interact()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}