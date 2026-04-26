using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    public float interactRange = 1.5f;

    void Update()
    {
        DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();
        QuizManager quizManager = FindObjectOfType<QuizManager>();

        if (dialogueManager != null && dialogueManager.IsDialogueActive())
            return;

        if (quizManager != null && quizManager.IsQuizActive())
            return;

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, interactRange);

            if (hit.collider != null)
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();

                if (interactable != null)
                {
                    interactable.Interact();
                }
            }
        }
    }
}