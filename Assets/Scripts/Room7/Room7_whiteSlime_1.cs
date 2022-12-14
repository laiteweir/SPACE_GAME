using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room7_whiteSlime_1 : Keyitem
{


    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // door_7_1.GetComponent<Door>().locked = false;
        // door_1_2.GetComponent<Door>().locked = false;
        // Debug.Log("try to open door 7_1");
        // Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
    }   
    // Update is called once per frame
    void Update()
    {
        if(this.rb.velocity.x == 0 || this.rb.velocity.y == 0){
            this.rb.velocity = new Vector2(Random.Range(-1f, 1f),Random.Range(-1f, 1f));
        }   
    }
    public override void KeyitemEvent()
    {
        //enable next process
        this.rb.velocity = new Vector2(Random.Range(-5f, 5f),Random.Range(-5f, 5f));
        //Debug.Log(Manager.Instance.dialogBox.TextIsOn);
    }
}
