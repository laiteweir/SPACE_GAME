using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room7_alien_controller : MonoBehaviour
{
    private Vector2 directionVector;
    // Start is called before the first frame update
    private Transform myTransform;
    public float speed;
    private Rigidbody2D rb;
    [SerializeField] ContactFilter2D movementFilter;
    readonly List<RaycastHit2D> castCollisions = new();
    [SerializeField] float collisionOffset = 0f;
    enum Condition
    {
        Success,
        Blocked,
        InputZero
    }
    void Start()
    {
        speed = 1;
        myTransform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        ChangeDirection();
    }

    private void Move(){
        Condition condition = TryMove(directionVector);
        if (condition == Condition.Blocked)
        {
            this.ChangeDirection();
        }
        else{
            rb.MovePosition((Vector2)myTransform.position + this.speed * Time.fixedDeltaTime * directionVector);
        }
        
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log(other);
        Vector2 temp = directionVector;
        ChangeDirection();
        int loops = 0;
        while (temp == directionVector && loops < 100)
        {
            loops++;
            ChangeDirection();
        }
    }
    void ChangeDirection(){
        int direction = Random.Range(0,4);
        switch(direction){
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
    // Update is called once per frame
    void Update()
    {
        Move();
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
