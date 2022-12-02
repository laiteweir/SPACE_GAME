using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1_event_SlimeMove : MonoBehaviour
{
    // Start is called before the first frame update
    public bool is_move = false;
    private int cnt =0;
    // Update is called once per frame
    void FixedUpdate()
    {
        if(is_move){
            cnt++;
            transform.Translate(Vector2.up * Time.deltaTime);//位移方法
        }
        if(ct>10)
        Destroy(gameObject);
    }
}
