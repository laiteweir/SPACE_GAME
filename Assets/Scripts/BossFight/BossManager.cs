using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject Boss;
    [SerializeField] GameObject Player;
    public bool win = false;
    void Start()
    {
        Boss.GetComponent<BossSmile>().bossHealth =3;

        Player.GetComponent<BreakController>().health =5;
    }

    // Update is called once per frame
    void Update()
    {
        if(Boss.GetComponent<BossSmile>().bossHealth ==0){
            backScene();
        }
        else if(Player.GetComponent<BreakController>().health ==0){
            backScene();
        }
    }

    void backScene(){
        Manager.Instance.returnKeyitem.EndKeyitemEvent();
    }
}
