using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float walkSpeed = 3f;
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float collisionOffset = 0f;
    [SerializeField] ContactFilter2D movementFilter;
    [SerializeField] Interact interact;
    [SerializeField] Inventory maybag;
    private float moveSpeed;
    private InputAction run;

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
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        GameObject spotLight = GameObject.Find("Spot Light");
        spotLight.GetComponent<Light2D>().intensity = 1;
        moveSpeed = walkSpeed;
        run = Manager.Instance.actionMapPlayer.FindAction("Run");
        run.started += context => StartRun();
        run.canceled += context => EndRun();
    }

    void FixedUpdate() 
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

        //Debug.Log(animator.GetBool("isWalking"));
    }

    private void StartRun()
    {
        moveSpeed = runSpeed;
    }

    private void EndRun()
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
            //Debug.Log(count);
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
        //Debug.Log("Fire Pressed!");
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
}
