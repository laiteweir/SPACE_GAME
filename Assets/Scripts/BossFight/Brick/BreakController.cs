using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class BreakController : MonoBehaviour
{
    
    private Rigidbody2D _myRD;
    private Vector2 _direction;
    public int health =5;
    [SerializeField] float speed =3;
    [SerializeField] GameObject slider;
    Animator animator;
    SpriteRenderer spriteRenderer;
    private InputAction run;
    public bool right = true;
    public bool is_moving = true;
    Slider slide;
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
        //run = Manager.Instance.actionMapPlayer.FindAction("Run");
        spriteRenderer = GetComponent<SpriteRenderer>();
        slide = slider.GetComponent<Slider>();
        slide.maxValue = health;
        // run.started += context => StartRun();
        // run.canceled += context => EndRun();
    }

    // Update is called once per frame
    void Update()
    {
        
        slide.value = health;
        if(Input.GetKey(KeyCode.A)){
            _direction = Vector2.left;
            animator.SetBool("isWalking", true);
            if(right){
                spriteRenderer.flipX = true;
                right = !right;
            }
            is_moving = true;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            _direction = Vector2.right;
             animator.SetBool("isWalking", true);
        
             if(!right){
                spriteRenderer.flipX = false;
                right = !right;
            }
            is_moving = true;
        }
        else{
            _direction = Vector2.zero;
            animator.SetBool("isWalking", false);
            is_moving = false;
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
