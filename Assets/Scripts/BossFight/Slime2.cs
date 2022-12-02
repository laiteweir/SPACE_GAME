using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime2 : MonoBehaviour
{
    private Rigidbody2D _myRD {get;set;}
    public float speed = 300f;
    public bool is_attack = false;
    

    // private void Awake(){
    //     _myRD = GetComponent<Rigidbody2D>();
    // }

    // void Start()
    // {
    //     Invoke(nameof(SetRandomTrajectory),0.5f);
    // }
    
    

    // // Update is called once per frame
    // void SetRandomTrajectory(){
    //     Vector2 force = Vector2.zero;
    //     force.x = Random.Range(-0.5f,0.5f);
    //     force.y = -1;
    //     _myRD.AddForce(force.normalized*speed);
    // }
}
