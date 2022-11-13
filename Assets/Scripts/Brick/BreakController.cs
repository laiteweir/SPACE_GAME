using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakController : MonoBehaviour
{
    
    private Rigidbody2D _myRD;
    private Vector2 _direction;
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
        _myRD.velocity = _direction*3;
    }
}
