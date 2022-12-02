using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSmile : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<GameObject> Smiles;
    [SerializeField] GameObject parent;
    [SerializeField] GameObject Player;
    [SerializeField] float speed = 300f;
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
            Invoke(nameof(GenerateNewSlime),0.1f);
        }
        timer += Time.deltaTime;
       //Debug.Log(transform.position.x);
        
       // Debug.Log(transform.position.x);
        _direction = (Vector2.left);

        

    }
    void OnTriggerEnter2D(Collider2D target){
        if(target.gameObject.tag == "slime2" && target.gameObject.GetComponent<Slime2>().is_attack){
            bossHealth--;
        }
    }

    void GenerateNewSlime(){
            GameObject newSmile = Instantiate(Smiles[number] );
            newSmile.transform.parent = gameObject.transform;
            newSmile.transform.position = parent.transform.position;
           // newSmile.Ge
            Vector2 force = Vector2.zero;
            force.x = Player.transform.position.x - gameObject.transform.position.x;
            force.y = Player.transform.position.y - gameObject.transform.position.y;
            newSmile.GetComponent<Rigidbody2D>().AddForce(force.normalized*speed);
            Debug.Log("generated");
    }
    
     void FixedUpdate(){
        if(transform.position.x <= 98 || transform.position.x >= 100 ){
            speed *=-1;
            //speed *= Random.Range(0.9f,1.1f);
            //Debug.Log(transform.position.x);
        }
        _myRD.velocity = _direction*speed;
        //speed = Random.Range(290f,310f);
    }
}
