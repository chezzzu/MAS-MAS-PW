using UnityEngine;
using System.Collections.Generic;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;

    public float followSpeed = 3f;
    public float followDistance = 1.5f;

    Rigidbody2D rb;
    Animator animator;

    Queue<Vector3> positions =
        new Queue<Vector3>();

    public int delayFrames = 10;

    Vector2 movement;
    Vector2 lastMovement;

    DialogueManager dialogueManager;
    QuizManager quizManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        dialogueManager = FindObjectOfType<DialogueManager>();
        quizManager = FindObjectOfType<QuizManager>();
    }

    void FixedUpdate()
    {
        if (player == null) return;

        // Stop saat dialogue atau quiz
        if ((dialogueManager != null && dialogueManager.IsDialogueActive()) ||
            (quizManager != null && quizManager.IsQuizActive()))
        {
            rb.linearVelocity = Vector2.zero;
            movement = Vector2.zero;
            UpdateAnimation();
            return;
        }

        positions.Enqueue(player.position);

        if (positions.Count > delayFrames)
        {
            Vector3 targetPos =
                positions.Dequeue();

            float distance =
                Vector2.Distance(
                    transform.position,
                    targetPos
                );

            if (distance > followDistance)
            {
                movement =
                    (targetPos - transform.position).normalized;

                rb.linearVelocity =
                    movement * followSpeed;
            }
            else
            {
                rb.linearVelocity = Vector2.zero;
                movement = Vector2.zero;
            }

            if (movement != Vector2.zero)
            {
                lastMovement = movement;
            }

            UpdateAnimation();
        }
    }

    void UpdateAnimation()
    {
        animator.SetFloat("InputX", movement.x);
        animator.SetFloat("InputY", movement.y);

        animator.SetFloat("LastInputX", lastMovement.x);
        animator.SetFloat("LastInputY", lastMovement.y);

        animator.SetBool("isWalking",
            rb.linearVelocity.magnitude > 0.1f);
    }
}