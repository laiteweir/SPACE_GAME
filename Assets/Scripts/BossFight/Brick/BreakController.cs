using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakController : MonoBehaviour
{
    
    private Rigidbody2D _myRD;
    private Vector2 _direction;
    public int health =5;
    [SerializeField] float speed =3;
    void Start()
    {
        _myRD = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow)){
            _direction = Vector2.left;
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            _direction = Vector2.right;
        }
        else{
            _direction = Vector2.zero;
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
