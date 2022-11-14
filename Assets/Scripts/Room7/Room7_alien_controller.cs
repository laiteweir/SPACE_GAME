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
    
    void Start()
    {
        myTransform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        ChangeDirection();
    }

    private void Move(){
        rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * directionVector);
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
}
