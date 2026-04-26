using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();
        QuizManager quizManager = FindObjectOfType<QuizManager>();

        if (dialogueManager != null && dialogueManager.IsDialogueActive())
        {
            rb.linearVelocity = Vector2.zero;
            animator.SetBool("isWalking", false);
            return;
        }

        if (quizManager != null && quizManager.IsQuizActive())
        {
            rb.linearVelocity = Vector2.zero;
            animator.SetBool("isWalking", false);
            return;
        }

        rb.linearVelocity = moveInput * moveSpeed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();
        QuizManager quizManager = FindObjectOfType<QuizManager>();

        if ((dialogueManager != null && dialogueManager.IsDialogueActive()) ||
            (quizManager != null && quizManager.IsQuizActive()))
        {
            moveInput = Vector2.zero;
            animator.SetBool("isWalking", false);
            return;
        }

        moveInput = context.ReadValue<Vector2>();

        animator.SetFloat("InputX", moveInput.x);
        animator.SetFloat("InputY", moveInput.y);

        if (moveInput != Vector2.zero)
        {
            animator.SetFloat("LastInputX", moveInput.x);
            animator.SetFloat("LastInputY", moveInput.y);
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }
}