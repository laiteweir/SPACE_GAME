using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D _myRD {get;set;}
    public float speed = 300f;
    

    private void Awake(){
        _myRD = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Invoke(nameof(SetRandomTrajectory),0.5f);
    }
    // Update is called once per frame
    void SetRandomTrajectory(){
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-0.5f,0.5f);
        force.y = -1;
        _myRD.AddForce(force.normalized*speed);
    }
    
}
