using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSmile : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<GameObject> Smiles;
    [SerializeField] GameObject parent;
    [SerializeField] float speed = 3f;
    float timer = 0f;
    private Vector2 _direction;
    private Rigidbody2D _myRD;
    int number;
    public int bossHealth =3;

     void Start()
    {
        _myRD = GetComponent<Rigidbody2D>();
    }

    void Update(){
        if(timer > 2){
            timer = 0;
            number = Random.Range(0,10);
            number %= Smiles.Count;
            var newSmile = Instantiate(Smiles[number] );
            newSmile.transform.parent = gameObject.transform;
            newSmile.transform.position = parent.transform.position;
            Vector2 force = Vector2.zero;
            force.x = 0;//Random.Range(-0.5f,0.5f);
            force.y = -3;
            newSmile.GetComponent<Rigidbody2D>().AddForce(force.normalized*speed);
        }
        timer += Time.deltaTime;
       //Debug.Log(transform.position.x);
        
        Debug.Log(transform.position.x);
        _direction = (Vector2.left);

    }
    void OnTriggerEnter2D(Collider2D target){
        if(target.gameObject.tag == "slime2" && target.gameObject.GetComponent<Slime2>().is_attack){
            bossHealth--;
        }
    }

     void FixedUpdate(){
        if(transform.position.x <= 98 || transform.position.x >= 100 ){
            speed *=-1;
            //Debug.Log(transform.position.x);
        }
        _myRD.velocity = _direction*speed;
    }
}
