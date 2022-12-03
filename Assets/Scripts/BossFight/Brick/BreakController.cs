using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class BreakController : MonoBehaviour
{
    
    private Rigidbody2D _myRD;
    private Vector2 _direction;
    public int health =5;
    [SerializeField] float speed =3;
    Animator animator;
    SpriteRenderer spriteRenderer;
    private InputAction run;
    bool right = true;
    enum Condition
    {
        Success,
        Blocked,
        InputZero
    }
    void Start()
    {
        _myRD = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        run = Manager.Instance.actionMapPlayer.FindAction("Run");
        spriteRenderer = GetComponent<SpriteRenderer>();
        // run.started += context => StartRun();
        // run.canceled += context => EndRun();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow)){
            _direction = Vector2.left;
            animator.SetBool("isWalking", true);
            if(!right){
                spriteRenderer.flipX = false;
                right = !right;
            }
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            _direction = Vector2.right;
             animator.SetBool("isWalking", true);
             if(right){
                spriteRenderer.flipX = true;
                right = !right;
            }
        }
        else{
            _direction = Vector2.zero;
            animator.SetBool("isWalking", false);
        }
    }
    void FixedUpdate(){
        _myRD.velocity = _direction*speed;
    }
    void OnCollisionEnter2D(Collision2D target){
        if(target.gameObject.tag == "slime1"){
            health--;
        }
        else if(target.gameObject.tag == "slime2"){
            target.gameObject.GetComponent<Slime2>().is_attack = true;
        }
    }
}
