using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class PaddleController : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 3f;
    [SerializeField] private float runSpeed = 5f;
    [SerializeField] private float collisionForce = 2f;
    [SerializeField] private float collisionOffset = 0.01f;
    [SerializeField] private ContactFilter2D movementFilter;
    [SerializeField] private Light2D spotLight;

    private float moveSpeed;
    private InputAction moveAction;
    private InputAction runAction;

    [HideInInspector] public bool right = true;
    [HideInInspector] public bool moving = false;
    private enum Condition
    {
        Success,
        Blocked,
        InputZero
    }
    private float movementInput;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private readonly List<RaycastHit2D> castCollisions = new();

    private void Awake()
    {
        moveAction = Manager.Instance.PlayerInput.actions["BossFight/Move"];
        runAction = Manager.Instance.PlayerInput.actions["BossFight/Run"];
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        spotLight.intensity = 0f;
        moveSpeed = walkSpeed;
    }
    private void OnEnable()
    {
        moveAction.performed += OnMove;
        moveAction.canceled += OnMove;
        runAction.started += StartRun;
        runAction.canceled += EndRun;
    }
    private void OnDisable()
    {
        moveAction.performed -= OnMove;
        moveAction.canceled -= OnMove;
        runAction.started -= StartRun;
        runAction.canceled -= EndRun;
    }

    private void FixedUpdate()
    {
        if (movementInput != 0f)
        {
            if (movementInput > 0f)
            {
                right = true;
                spriteRenderer.flipX = false;
            }
            else if (movementInput < 0f)
            {
                right = false;
                spriteRenderer.flipX = true;
            }

            Condition condition;

            bool isMoving = TryMove(movementInput);

            if (isMoving)
            {
                condition = Condition.Success;
            }
            else
            {
                condition = Condition.Blocked;
            }

            if (condition == Condition.Success)
            {
                moving = true;
                animator.SetBool("isWalking", true);
            }
            else
            {
                moving = false;
                animator.SetBool("isWalking", false);
            }
        }
        else
        {
            moving = false;
            animator.SetBool("isWalking", false);
        }
    }

    private bool TryMove(float x)
    {
        Vector2 direction = new(x, 0);
        if (direction == Vector2.zero)
        {
            return false;
        }
        int count = rb.Cast(
            direction,
            movementFilter,
            castCollisions,
            moveSpeed * Time.fixedDeltaTime + collisionOffset);
        if (count == 0)
        {
            rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * direction);
            return true;
        }
        else
        {
            RaycastHit2D col = castCollisions[0];
            if (col.rigidbody != null && col.rigidbody.bodyType == RigidbodyType2D.Dynamic)
            {
                col.rigidbody.AddForce(direction * collisionForce, ForceMode2D.Impulse);
            }
            return false;
        }
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<float>();
    }
    private void StartRun(InputAction.CallbackContext context)
    {
        moveSpeed = runSpeed;
    }
    private void EndRun(InputAction.CallbackContext context)
    {
        moveSpeed = walkSpeed;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        GameObject other = col.gameObject;
        if (other.CompareTag("BlackSlime"))
        {
            --BossFightManager.Instance.playerHealth;
        }
    }
}
