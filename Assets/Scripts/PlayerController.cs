using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    public Interact interact;
    public Inventory maybag;

    enum Condition
    {
        Success,
        Blocked,
        InputZero
    }
    bool canMove = true;
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
        maybag.itemList.Clear();
    }

    void FixedUpdate() 
    {
        if (canMove && movementInput != Vector2.zero)
        {
            if (movementInput.x < 0f)
            {
                spriteRenderer.flipX = true;
            }
            else if (movementInput.x > 0f)
            {
                spriteRenderer.flipX = false;
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
        if (spriteRenderer.flipX)
        {
            interact.InteractLeft();
        }
        else
        {
            interact.InteractRight();
        }
    }

    public void EndKeyitemInteract()
    {
        UnlockMovement();
        interact.StopInteract();
    }
}
