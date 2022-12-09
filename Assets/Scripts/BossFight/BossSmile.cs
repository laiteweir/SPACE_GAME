using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossSmile : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<GameObject> Smiles;
    [SerializeField] GameObject parent;
    [SerializeField] GameObject Player;
    [SerializeField] float speed = 300f;
    [SerializeField] GameObject slider;
    float timer = 0f;
    private Vector2 _direction;
    private Rigidbody2D _myRD;
    int number;
    public Vector2 force;
    public int bossHealth =3;
    private static float y_dis = -3.5291f;
    private float slimeSpeed = 2f;
    private bool stage2 = true;
    Slider slide;
     void Start()
    {
        _myRD = GetComponent<Rigidbody2D>();
        slide = slider.GetComponent<Slider>();
        slide.maxValue = bossHealth;
        force.y = Player.transform.position.y - gameObject.transform.position.y;
    }

    void Update(){
        slide.value = bossHealth;
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
        if(bossHealth <= 1 && stage2){
            speed = 3f;
            stage2 = !stage2;
        }
        

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
            //Vector2 force = Vector2.zero;
            force.x = Player.transform.position.x - gameObject.transform.position.x;
            //force.y = y_dis;
            if(Player.GetComponent<BreakController>().is_moving){
                if(Player.GetComponent<BreakController>().right)
                    force.x += 0.3f;
                else
                    force.x -= 0.3f;
            }
            newSmile.GetComponent<Rigidbody2D>().AddForce(force.normalized*slimeSpeed);
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
