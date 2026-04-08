using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 3f;
    [SerializeField] private float runSpeed = 5f;
    [SerializeField] private float collisionOffset = 0f;
    [SerializeField] private ContactFilter2D movementFilter;
    [SerializeField] private Interact interact;
    [SerializeField] private Light2D spotLight;

    private float moveSpeed;
    private InputAction move;
    private InputAction run;
    private InputAction pauseAction;
    private InputAction inventoryAction;

    enum Condition
    {
        Success,
        Blocked,
        InputZero
    }
    bool canMove = true;
    bool isVertical = false;
    bool flipy = false;
    Vector2 movementInput;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    Animator animator;
    readonly List<RaycastHit2D> castCollisions = new();

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        spotLight.intensity = 1f;
        moveSpeed = walkSpeed;
        move = Manager.Instance.PlayerInput.actions["Player/Move"];
        move.started += PlayWalkingSound;
        move.canceled += StopWalkingSound;
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
        move.started -= PlayWalkingSound;
        move.canceled -= StopWalkingSound;
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

            Condition condition = TryMove(movementInput);
            
            if (condition == Condition.Blocked)
            {
                condition = TryMove(new Vector2(movementInput.x, 0)); 
            }

            if (condition == Condition.Blocked)
            {
                condition = TryMove(new Vector2(0, movementInput.y));
            }

            if (condition == Condition.Success)
            {
                animator.SetBool("isWalking", true);
            }
            else
            {
                animator.SetBool("isWalking", false);
            }
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        // Debug.Log(animator.GetBool("isWalking"));
    }

    private void PlayWalkingSound(InputAction.CallbackContext context)
    {
        Manager.Instance.WalkingSound.walkingSoundPlay = true;
        Manager.Instance.WalkingSound.walkingSoundToggleChange = true;
    }

    private void StopWalkingSound(InputAction.CallbackContext context)
    {
        Manager.Instance.WalkingSound.walkingSoundPlay = false;
        Manager.Instance.WalkingSound.walkingSoundToggleChange = true;
    }

    private void StartRun(InputAction.CallbackContext context)
    {
        moveSpeed = runSpeed;
    }

    private void EndRun(InputAction.CallbackContext context)
    {
        moveSpeed = walkSpeed;
    }

    private Condition TryMove(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            int count = rb.Cast(
                    direction,
                    movementFilter,
                    castCollisions,
                    moveSpeed * Time.fixedDeltaTime + collisionOffset);
            // Debug.Log(count);
            if (count == 0)
            {
                rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * direction);
                return Condition.Success;
            }
            else
            {
                return Condition.Blocked;
            }
        }
        else
        {
            return Condition.InputZero;
        }
    }

    public void OnMove(InputValue movementValue){
        movementInput = movementValue.Get<Vector2>();
    }

    public void OnFire()
    {
        // Debug.Log("Fire Pressed!");
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
