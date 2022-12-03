using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class Room7_alien_controller : MonoBehaviour
{
    private Vector2 directionVector = Vector2.down;
    // Start is called before the first frame update
    private Transform myTransform;
    public float speed;
    private Rigidbody2D rb;
    [SerializeField] ContactFilter2D movementFilter;
    readonly List<RaycastHit2D> castCollisions = new();
    [SerializeField] float collisionOffset = 0f;
    // private bool isTouch = false;
    private int auto_change_direction = 0;
    [SerializeField] TextAsset textFile;
    private string[] dialog;
    enum Condition
    {
        Success,
        Blocked,
        InputZero
    }
    void Start()
    {
        speed = 0.5f;
        myTransform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Move(){
        
        Condition condition = TryMove(directionVector);
 
        if (condition != Condition.Blocked)
        {
            
            auto_change_direction++;
            if(auto_change_direction > 500){
                this.ChangeDirection(directionVector);
                auto_change_direction = 0;
            }
            rb.MovePosition((Vector2)myTransform.position + this.speed * Time.fixedDeltaTime * directionVector);
        }
        else{
            this.ChangeDirectionGoback(directionVector);
        }
        
        
    }

    // private void OnCollisionEnter2D(Collision2D other) {
    //     Debug.Log(other);
    //     // Vector2 temp = directionVector;
    //     // ChangeDirection();
    //     // int loops = 0;
    //     // while (temp == directionVector && loops < 100)
    //     // {
    //     //     loops++;
    //     //     ChangeDirection();
    //     // }
    // }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(  !Manager.Instance.room7.isTouch && col.gameObject.name == "Player"){
            Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
            Manager.Instance.room7.isTouch = true;
            // Manager.Instance.playerController.SetPlayerSpeed(0.1f);
        }
    }    
    void ChangeDirectionGoback(Vector2 directionVector){
        if(directionVector==Vector2.up){
            this.directionVector = Vector2.down;
        }
        else if(directionVector==Vector2.down){
            this.directionVector = Vector2.up;
        }
        else if(directionVector==Vector2.left){
            this.directionVector = Vector2.right;
        }
        else if(directionVector==Vector2.right){
            this.directionVector = Vector2.left;
        }
    }
    void ChangeDirection(Vector2 directionVector){
        int direction = Random.Range(0,4);
        switch(direction){
            case 0:
                this.directionVector = Vector2.right;
                break;
            case 1:
                this.directionVector = Vector2.left;
                break;
            case 2:
                this.directionVector = Vector2.up;
                break;
            case 3:
                this.directionVector = Vector2.down;
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
