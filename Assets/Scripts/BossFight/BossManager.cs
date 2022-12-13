using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject Boss;
    [SerializeField] GameObject Player;
    [SerializeField] Inventory mybag;
    [SerializeField] GameObject slider;
    public bool win = false;
    private int playerhealth = 5;
    public string keyword;
    Slider slide;
    void Start()
    {
        Boss.GetComponent<BossSmile>().bossHealth =3;
        for(int i=0; i<mybag.itemList.Count ;i++){
            if(mybag.itemList[i].itemName == keyword){
                    playerhealth = 10;
            }
        }
        Player.GetComponent<BreakController>().health = playerhealth;
        slide = slider.GetComponent<Slider>();
        slide.maxValue = playerhealth;
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
