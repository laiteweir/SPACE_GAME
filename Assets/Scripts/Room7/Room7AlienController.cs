using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room7AlienController : MonoBehaviour
{
    private Vector2 directionVector = Vector2.down;
    private Transform thisTransform;
    private float speed;
    private Rigidbody2D rb;
    [SerializeField] private ContactFilter2D movementFilter;
    private readonly List<RaycastHit2D> castCollisions = new();
    [SerializeField] private float collisionOffset = 0f;
    private bool isTouch = false;
    private int changeDirectionCounter = 0;

    private enum Condition
    {
        Success,
        Blocked,
        InputZero
    }

    // Start is called before the first frame update
    private void Start()
    {
        speed = 0.5f;
        thisTransform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Condition condition = TryMove(directionVector);
 
        if (condition == Condition.Blocked)
        {
            BounceBack(directionVector);
        }
        else
        {
            ++changeDirectionCounter;
            if (changeDirectionCounter > 500)
            {
                ChangeDirection();
                changeDirectionCounter = 0;
            }
            rb.MovePosition((Vector2)thisTransform.position + speed * Time.fixedDeltaTime * directionVector);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isTouch && other.gameObject.CompareTag("Player"))
        {
            // Debug.Log(other.gameObject.name + " : " + gameObject.name + " : " + Time.time);
            isTouch = true;
        }
    }

    private void BounceBack(Vector2 previousDirectionVector)
    {
        if (previousDirectionVector == Vector2.up)
        {
            directionVector = Vector2.down;
        }
        else if (previousDirectionVector == Vector2.down)
        {
            directionVector = Vector2.up;
        }
        else if (previousDirectionVector == Vector2.left)
        {
            directionVector = Vector2.right;
        }
        else if (previousDirectionVector == Vector2.right)
        {
            directionVector = Vector2.left;
        }
    }
    private void ChangeDirection()
    {
        int direction = Random.Range(0,4);
        switch(direction)
        {
            case 0:
                directionVector = Vector2.right;
                break;
            case 1:
                directionVector = Vector2.left;
                break;
            case 2:
                directionVector = Vector2.up;
                break;
            case 3:
                directionVector = Vector2.down;
                break;
            default:
                break;
        }
    }

    private Condition TryMove(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            int count = rb.Cast(
                direction,
                movementFilter,
                castCollisions,
                speed * Time.fixedDeltaTime + collisionOffset);
            
            if (count == 0)
            {
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
}
