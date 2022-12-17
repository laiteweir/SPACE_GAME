using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_boss_move : MonoBehaviour
{
    // Start is called before the first frame update
    public bool is_move = false;
    private int cnt =0;
    public GameObject BossEvent;
    // Update is called once per frame
    void Start(){
        Manager.Instance.actionMapPlayer.Disable();
    }
    void FixedUpdate()
    {
        if(is_move){
            cnt++;
            transform.Translate(Vector2.down * Time.deltaTime);//位移方法
        }
        if(cnt>100){
            BossEvent.SetActive(true);
            Manager.Instance.actionMapPlayer.Enable();
            Destroy(gameObject);
        }
    }
}
