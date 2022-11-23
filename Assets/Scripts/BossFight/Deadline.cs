using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadline : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "slime1" || collision.gameObject.tag == "slime2" ){
            Destroy(collision.gameObject);
        }
    }
}
