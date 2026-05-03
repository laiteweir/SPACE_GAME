using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 3f;
    [SerializeField] private float runSpeed = 5f;
    [SerializeField] private float collisionForce = 2f;
    [SerializeField] private float collisionOffset = 0.01f;
    [SerializeField] private ContactFilter2D movementFilter;
    [SerializeField] private Interact interact;
    [SerializeField] private Light2D spotLight;

    private float moveSpeed;
    private InputAction run;
    private InputAction pauseAction;
    private InputAction inventoryAction;

    private enum Condition
    {
        Success,
        Blocked,
        InputZero
    }
    private bool canMove = true;
    private bool isVertical = false;
    private bool flipy = false;
    private Vector2 movementInput;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private readonly List<RaycastHit2D> castCollisions = new();

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        spotLight.intensity = 1f;
        moveSpeed = walkSpeed;
        run = Manager.Instance.PlayerInput.actions["Player/Run"];
        run.started += StartRun;
        run.canceled += EndRun;
        pauseAction = Manager.Instance.PlayerInput.actions["Player/Pause"];
        pauseAction.performed += Manager.Instance.PauseMenu.OnPausePerformed;
        inventoryAction = Manager.Instance.PlayerInput.actions["Player/Inventory"];
        inventoryAction.performed += Manager.Instance.Inventory.OnInventoryPerformed;
    }
    private void OnDestroy()
    {
        run.started -= StartRun;
        run.canceled -= EndRun;
        pauseAction.performed -= Manager.Instance.PauseMenu.OnPausePerformed;
        inventoryAction.performed -= Manager.Instance.Inventory.OnInventoryPerformed;
    }
    private void FixedUpdate() 
    {
        if (canMove && movementInput != Vector2.zero)
        {
            if (movementInput.x > 0f)
            {
                isVertical = false;
                spriteRenderer.flipX = false;
            }
            else if (movementInput.x < 0f)
            {
                isVertical = false;
                spriteRenderer.flipX = true;
            }
            else if (movementInput.y > 0f)
            {
                isVertical = true;
                flipy = false;
            }
            else if (movementInput.y < 0f)
            {
                isVertical = true;
                flipy = true;
            }

            bool isMoving1 = false;
            bool isMoving2 = false;
            bool isMoving3 = false;
            Condition condition;

            isMoving1 = TryMove(movementInput);
            if (!isMoving1)
            {
                isMoving2 = TryMove(new Vector2(movementInput.x, 0)); 
            }
            if (!isMoving1)
            {
                isMoving3 = TryMove(new Vector2(0, movementInput.y));
            }

            if (isMoving1 || isMoving2 || isMoving3)
            {
                condition = Condition.Success;
            }
            else
            {
                condition = Condition.Blocked;
            }

            if (condition == Condition.Success)
            {
                animator.SetBool("isWalking", true);
                Manager.Instance.WalkingSound.PlayWalkingSound();
            }
            else
            {
                Manager.Instance.WalkingSound.StopWalkingSound();
                animator.SetBool("isWalking", false);
            }
        }
        else
        {
            Manager.Instance.WalkingSound.StopWalkingSound();
            animator.SetBool("isWalking", false);
        }
    }

    private void StartRun(InputAction.CallbackContext context)
    {
        moveSpeed = runSpeed;
    }
    private void EndRun(InputAction.CallbackContext context)
    {
        moveSpeed = walkSpeed;
    }

    private bool TryMove(Vector2 direction)
    {
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

    public void OnMove(InputValue movementValue){
        movementInput = movementValue.Get<Vector2>();
    }
    public void OnFire()
    {
        animator.SetTrigger("keyitemInteract");
    }

    public void LockMovement ()
    {
        canMove = false;
    }
    public void UnlockMovement()
    {
        canMove = true;
    }

    public void KeyitemInteract()
    {
        LockMovement();
        if (isVertical)
        {
            if (flipy)
            {
                interact.InteractDown();
            }
            else
            {
                interact.InteractTop();
            }
        }
        else
        {
            if (spriteRenderer.flipX)
            {
                interact.InteractLeft();
            }
            else
            {
                interact.InteractRight();
            }
        }
    }
    public void EndKeyitemInteract()
    {
        UnlockMovement();
        interact.StopInteract();
    }

    public void SetPlayerSpeed(float sp)
    {
        walkSpeed *= sp;
        runSpeed *= sp;
    }
}
